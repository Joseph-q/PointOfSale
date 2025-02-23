using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;
using PointOfSale.Permissions;

namespace PointOfSale.Permitions
{
    public class PermissionService(CorteDeCajaContext context) : IPermissionService
    {
        private readonly CorteDeCajaContext _context = context;

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
