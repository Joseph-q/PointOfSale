using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;

namespace PointOfSale.Identity.Permitions
{
    public class PermissionService(SalesContext context) : IPermissionService
    {
        private readonly SalesContext _context = context;

        public Task<List<Permission>> FindPermitionByIds(HashSet<int> permissionIDs)
        {
            return _context.Permissions.Where(p => permissionIDs.Contains(p.Id)).ToListAsync();
        }

        public Task<List<Permission>> FindPermitionByIds(HashSet<int> permissionIDs, CancellationToken cancellationToken)
        {
            return _context.Permissions.Where(p => permissionIDs.Contains(p.Id)).ToListAsync(cancellationToken);
        }
    }
}
