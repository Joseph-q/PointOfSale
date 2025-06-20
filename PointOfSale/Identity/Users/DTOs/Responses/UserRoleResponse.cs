﻿namespace PointOfSale.Identity.Users.Controllers.DTOs.Responses
{
    public record UserRoleResponse
    {
        public int Id { get; init; }
        public required string Name { get; init; }
        public required string Description { get; init; }

    }
}
