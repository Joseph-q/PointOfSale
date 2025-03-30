namespace PointOfSale.Identity.Users.Controllers.DTOs.Responses
{
    public record UserDTO
    {
        public int Id { get; init; }
        public required string Username { get; init; }

        public DateTime? CreatedAt { get; init; }

        public required List<UserRoleDTO?> Roles { get; init; }
    }
}
