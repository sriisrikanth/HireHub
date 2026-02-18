using HireHub.Core.Data.Filters;
using HireHub.Core.Data.Models;
using HireHub.Shared.Persistence.Interface;

namespace HireHub.Core.Data.Interface;

public interface IDriveRepository : IGenericRepository<Drive>
{
    #region DQL

    Task<List<Drive>> GetAllAsync(DriveFilter filter, CancellationToken cancellationToken = default);
    Task<bool> IsUserAssignedInAnyActiveDriveOnDateAsync(int userId, DateTime driveDate, CancellationToken cancellationToken = default);

    #endregion

    #region DML



    #endregion
}