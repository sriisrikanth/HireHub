using HireHub.Core.Data.Models;
using HireHub.Shared.Persistence.Interface;

namespace HireHub.Core.Data.Interface;

public interface IInterviewRepository : IGenericRepository<Interview>
{
    #region DQL

    Task<int> CountInterviewsAsync(CancellationToken cancellationToken = default);

    #endregion

    #region DML



    #endregion
}