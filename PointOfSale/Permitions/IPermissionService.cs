using PointOfSale.Models;

namespace PointOfSale.Permissions
{
    public interface IPermissionService
    {
        Task<List<Permission>> FindPermitionByIds(HashSet<int> permissionIDs);

        Task<List<Permission>> FindPermitionByIds(HashSet<int> permissionIDs, CancellationToken cancellationToken);

    }
}
