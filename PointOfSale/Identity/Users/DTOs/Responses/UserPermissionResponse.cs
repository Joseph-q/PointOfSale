namespace PointOfSale.Identity.Users.DTOs.Responses
{
    public record UserPermissionResponse
    {
        public int Id { get; init; }

        public string Action { get; init; } = string.Empty;

        public string Subject { get; init; } = string.Empty;

        public string? Condition { get; init; }

        public bool? Inverted { get; init; }
    }
}
