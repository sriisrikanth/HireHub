using HireHub.Api.Utils.Filters;
using HireHub.Core.Data.Interface;
using HireHub.Core.Data.Models;
using HireHub.Core.DTO;
using HireHub.Core.DTO.Base;
using HireHub.Core.Service;
using HireHub.Core.Utils.Common;
using HireHub.Core.Utils.UserProgram.Interface;
using HireHub.Core.Validators;
using HireHub.Shared.Authentication.Filters;
using HireHub.Shared.Common.Exceptions;
using HireHub.Shared.Common.Models;
using HireHub.Shared.Middleware.Models;
using Microsoft.AspNetCore.Mvc;

namespace HireHub.Api.Controllers;

[RequireAuth]
[Route("api/[controller]")]
[ApiController]
public class DriveController : ControllerBase
{
    private readonly DriveService _driveService;
    private readonly IUserProvider _userProvider;
    private readonly RepoService _repoService;
    private readonly ITransactionRepository _transactionRepository;
    private readonly ILogger<DriveController> _logger;

    public DriveController(DriveService driveService, IUserProvider userProvider,
        RepoService repoService, ITransactionRepository transactionRepository,
        ILogger<DriveController> logger)
    {
        _driveService = driveService;
        _userProvider = userProvider;
        _repoService = repoService;
        _transactionRepository = transactionRepository;
        _logger = logger;
    }


    #region Get API's

    [RequireAuth([RoleName.Admin])]
    [RequirePermission(UserAction.Drive, ActionType.View)]
    [HttpGet("fetch/all")]
    [ProducesResponseType<Response<List<DriveDTO>>>(200)]
    [ProducesResponseType<BaseResponse>(400)]
    [ProducesResponseType<ErrorResponse>(500)]
    public async Task<IActionResult> GetDrives([FromQuery] string? driveStatus,
        [FromQuery] string? creatorEmail, [FromQuery] int? technicalRounds, [FromQuery] bool isLatestFirst, 
        [FromQuery] bool includePastDrives, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate,
        [FromQuery] int? pageNumber, [FromQuery] int? pageSize)
    {
        _logger.LogInformation(LogMessage.StartMethod, nameof(GetDrives));

        try
        {
            object? status = null;
            if (driveStatus != null && !Enum.TryParse(typeof(DriveStatus), driveStatus, true, out status))
                throw new CommonException(ResponseMessage.InvalidExperienceLevel);

            var response = await _driveService.GetDrives(
                status != null ? (DriveStatus)status : null,
                creatorEmail, technicalRounds, isLatestFirst, includePastDrives,
                startDate, endDate, pageNumber, pageSize);

            _logger.LogInformation(LogMessage.EndMethod, nameof(GetDrives));

            return Ok(response);
        }
        catch (CommonException ex)
        {
            _logger.LogWarning(LogMessage.EndMethodException, nameof(GetDrives), ex.Message);
            return BadRequest(new BaseResponse
            {
                Errors = [
                    new ValidationError { PropertyName = PropertyName.Main, ErrorMessage = ex.Message }
                ]
            });
        }
    }

    #endregion

    #region Post API's

    [RequireAuth([RoleName.Admin])]
    [RequirePermission(UserAction.Drive, ActionType.Add)]
    [HttpPost("create")]
    [ProducesResponseType<Response<DriveDTO>>(200)]
    [ProducesResponseType<BaseResponse>(400)]
    [ProducesResponseType<ErrorResponse>(500)]
    public async Task<IActionResult> CreateDrive([FromBody] CreateDriveRequest request)
    {
        _logger.LogInformation(LogMessage.StartMethod, nameof(CreateDrive));

        try
        {
            using (_transactionRepository.BeginTransaction())
            {
                var baseResponse = new BaseResponse();

                var validator = await new CreateDriveRequestValidator(baseResponse.Warnings, _repoService, _userProvider)
                    .ValidateAsync(request);

                if (!validator.IsValid)
                {
                    validator.Errors.ForEach(e =>
                        baseResponse.Errors.Add(new ValidationError
                        {
                            PropertyName = e.PropertyName,
                            ErrorMessage = e.ErrorMessage
                        })
                    );
                    return BadRequest(baseResponse);
                }

                var currentUserId = int.Parse(_userProvider.CurrentUserId);
                var response = await _driveService.CreateDriveAsync(request, currentUserId);

                baseResponse.Warnings.ForEach(response.Warnings.Add);

                _transactionRepository.CommitTransaction();

                _logger.LogInformation(LogMessage.EndMethod, nameof(CreateDrive));

                return Ok(response);
            }
        }
        catch (CommonException ex)
        {
            _logger.LogWarning(LogMessage.EndMethodException, nameof(CreateDrive), ex.Message);
            _transactionRepository.RollbackTransaction();
            return BadRequest(new BaseResponse
            {
                Errors = [
                    new ValidationError { PropertyName = PropertyName.Main, ErrorMessage = ex.Message }
                ]
            });
        }
    }

    #endregion
}