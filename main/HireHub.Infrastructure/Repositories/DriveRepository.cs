using HireHub.Core.Data.Filters;
using HireHub.Core.Data.Interface;
using HireHub.Core.Data.Models;
using HireHub.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HireHub.Infrastructure.Repositories;

public class DriveRepository : GenericRepository<Drive>, IDriveRepository
{
    private new readonly HireHubDbContext _context;

    public DriveRepository(HireHubDbContext context) : base(context)
    {
        _context = context;
    }


    #region DQL

    public async Task<List<Drive>> GetAllAsync(DriveFilter filter, CancellationToken cancellationToken = default)
    {
        var query = _context.Drives.Include(e => e.Creator).Select(u => u);

        if (filter.Status != null)
            query = query
                .Where(d => d.Status == filter.Status);

        if (filter.CreatorEmail != null)
            query = query
                .Where(d => d.Creator!.Email == filter.CreatorEmail);

        if (filter.TechnicalRounds != null)
            query = query
                .Where(d => d.TechnicalRounds == filter.TechnicalRounds);

        if (!filter.IncludePastDrives)
            query = query
                .Where(d => d.DriveDate >= DateTime.Today);

        if (filter.StartDate != null)
            query = query
                .Where(d => d.DriveDate >= filter.StartDate);

        if (filter.EndDate != null)
            query = query
                .Where(d => d.DriveDate <= filter.EndDate);

        if (filter.PageNumber != null && filter.PageSize != null)
        {
            var pageNumber = (int)filter.PageNumber;
            var pageSize = (int)filter.PageSize;
            query = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }

        query = filter.IsLatestFirst ?
            query.OrderByDescending(d => d.DriveDate).ThenByDescending(d => d.CreatedDate) :
            query.OrderBy(u => u.DriveDate).ThenBy(d => d.CreatedDate);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<bool> IsUserAssignedInAnyActiveDriveOnDateAsync(int userId, DateTime driveDate, 
        CancellationToken cancellationToken = default)
    {
        return await _context.DriveTeams
            .Where(dm => dm.UserId == userId)
            .Include(dm => dm.Drive)
            .AnyAsync(
                dm => dm.Drive!.DriveDate.Date == driveDate.Date && dm.Drive.Status != DriveStatus.Completed,
                cancellationToken
            );
    }

    #endregion

    #region DML



    #endregion

    #region Private Methods



    #endregion
}
