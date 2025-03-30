using PointOfSale.Models;

namespace PointOfSale.Identity.Permitions
{
    public interface IPermissionService
    {
        Task<List<Permission>> FindPermitionByIds(HashSet<int> permissionIDs);

        Task<List<Permission>> FindPermitionByIds(HashSet<int> permissionIDs, CancellationToken cancellationToken);

    }
}
