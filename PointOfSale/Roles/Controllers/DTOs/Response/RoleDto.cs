namespace PointOfSale.Roles.Controllers.DTOs.Response
{
    public record RoleDto
    {
        public required int Id { get; init; }
        public required string Name { get; init; }
        public required string Description { get; init; }

    }
}
