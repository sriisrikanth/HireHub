using HireHub.Core.Data.Filters;
using HireHub.Core.Data.Interface;
using HireHub.Core.Data.Models;
using HireHub.Core.DTO;
using HireHub.Core.Utils.Common;
using HireHub.Shared.Common.Exceptions;
using Microsoft.Extensions.Logging;

namespace HireHub.Core.Service;

public class CandidateService
{
    private readonly ICandidateRepository _candidateRepository;
    private readonly ISaveRepository _saveRepository;
    private readonly ILogger<CandidateService> _logger;

    public CandidateService(ICandidateRepository candidateRepository,
        ISaveRepository saveRepository, ILogger<CandidateService> logger)
    {
        _candidateRepository = candidateRepository;
        _saveRepository = saveRepository;
        _logger = logger;
    }


    #region Query Services

    public async Task<Response<List<CandidateDTO>>> GetCandidates(CandidateExperienceLevel? experienceLevel,
        bool isLatestFirst, DateTime? startDate, DateTime? endDate, int? pageNumber, int? pageSize)
    {
        _logger.LogInformation(LogMessage.StartMethod, nameof(GetCandidates));

        var filter = new CandidateFilter
        {
            ExperienceLevel = experienceLevel, IsLatestFirst = isLatestFirst,
            StartDate = startDate, EndDate = endDate,
            PageNumber = pageNumber, PageSize = pageSize
        };
        var candidates = await _candidateRepository.GetAllAsync(filter, CancellationToken.None);

        var candidateDTOs = ConverToDTO(candidates);

        _logger.LogInformation(LogMessage.EndMethod, nameof(GetCandidates));

        return new() { Data = candidateDTOs };
    }


    public async Task<Response<CandidateCompleteDetailsDTO>> GetCandidate(int candidateId)
    {
        _logger.LogInformation(LogMessage.StartMethod, nameof(GetCandidate));

        var candidate = await _candidateRepository.GetByIdAsync(candidateId) ??
            throw new CommonException(ResponseMessage.CandidateNotFound);

        var candidateDTO = Helper.Map<Candidate, CandidateCompleteDetailsDTO>(candidate);
        candidateDTO.CandidateExperienceLevel = candidate.ExperienceLevel.ToString();

        _logger.LogInformation(LogMessage.EndMethod, nameof(GetCandidate));

        return new() { Data = candidateDTO };
    }

    #endregion

    #region Command Services

    public async Task<Response<CandidateDTO>> AddCandidate(AddCandidateRequest request)
    {
        _logger.LogInformation(LogMessage.StartMethod, nameof(AddCandidate));

        var candidate = Helper.Map<AddCandidateRequest, Candidate>(request);
        candidate.ExperienceLevel = (CandidateExperienceLevel)Enum
            .Parse(typeof(CandidateExperienceLevel), request.ExperienceLevelName, true);

        await _candidateRepository.AddAsync(candidate, CancellationToken.None);
        _saveRepository.SaveChanges();

        var candidateDTO = Helper.Map<Candidate, CandidateDTO>(candidate);
        candidateDTO.CandidateExperienceLevel = candidate.ExperienceLevel.ToString();

        _logger.LogInformation(LogMessage.EndMethod, nameof(AddCandidate));

        return new() { Data = candidateDTO };
    }

    public async Task<Response<List<int>>> InsertCandidatesBulk(List<AddCandidateRequest> request)
    {
        _logger.LogInformation(LogMessage.StartMethod, nameof(InsertCandidatesBulk));

        var candidates = new List<Candidate>();
        request.ForEach(req =>
        {
            var candidate = Helper.Map<AddCandidateRequest, Candidate>(req);
            candidate.ExperienceLevel = (CandidateExperienceLevel)Enum
                .Parse(typeof(CandidateExperienceLevel), req.ExperienceLevelName, true);
            candidates.Add(candidate);
        });

        await _candidateRepository.BulkInsertAsync(candidates, CancellationToken.None);
        _saveRepository.SaveChanges();

        var ids = new List<int>();
        candidates.ForEach(c => ids.Add(c.CandidateId));

        _logger.LogInformation(LogMessage.EndMethod, nameof(InsertCandidatesBulk));

        return new() { Data = ids };
    }

    #endregion

    #region Private Methods

    private List<CandidateDTO> ConverToDTO(List<Candidate> candidates)
    {
        var candidateDTOs = new List<CandidateDTO>();
        candidates.ForEach(candidate =>
        {
            var candidateDTO = Helper.Map<Candidate, CandidateDTO>(candidate);
            candidateDTO.CandidateExperienceLevel = candidate.ExperienceLevel.ToString();
            candidateDTOs.Add(candidateDTO);
        });
        return candidateDTOs;
    }

    #endregion
}