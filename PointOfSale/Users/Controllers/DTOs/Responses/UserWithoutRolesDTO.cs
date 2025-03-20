namespace PointOfSale.Users.Controllers.DTOs.Responses
{
    public record UserWithoutRolesDTO
    {
        public int Id { get; init; }
        public required string Username { get; init; }

        public DateTime? CreatedAt { get; init; }

    }
}
