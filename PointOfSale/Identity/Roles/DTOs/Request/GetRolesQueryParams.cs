﻿using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Identity.Roles.DTOs.Request
{
    public record GetRolesQueryParams
    {
        [Range(1, int.MaxValue, ErrorMessage = "El número de página debe ser mayor o igual a 1.")]
        public int Page { get; init; } = 1;


        [Range(1, int.MaxValue, ErrorMessage = "El límite debe ser mayor o igual a 1.")]
        public int Limit { get; init; } = 20;
    }
}
