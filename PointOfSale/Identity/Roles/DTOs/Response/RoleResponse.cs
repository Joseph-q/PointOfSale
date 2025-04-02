﻿namespace PointOfSale.Identity.Roles.DTOs.Response
{
    public record RoleResponse
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
    }
}
