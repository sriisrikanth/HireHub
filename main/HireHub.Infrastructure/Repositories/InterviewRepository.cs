using HireHub.Core.Data.Interface;
using HireHub.Core.Data.Models;
using HireHub.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HireHub.Infrastructure.Repositories;

public class InterviewRepository : GenericRepository<Interview>, IInterviewRepository
{
    private new readonly HireHubDbContext _context;

    public InterviewRepository(HireHubDbContext context) : base(context)
    {
        _context = context;
    }


    #region DQL

    public async Task<int> CountInterviewsAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Interviews.CountAsync(cancellationToken);
    }

    #endregion

    #region DML



    #endregion

    #region Private Methods



    #endregion
}
