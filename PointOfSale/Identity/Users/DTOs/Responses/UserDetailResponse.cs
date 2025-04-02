namespace PointOfSale.Identity.Users.Controllers.DTOs.Responses
{
    public record UserDetailResponse
    {
        public string Id { get; init; } = string.Empty;
        public string Username { get; init; } = string.Empty;
        public string FullName { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public bool EmailConfirmed { get; init; }
        public int Logins { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }

    }
}
