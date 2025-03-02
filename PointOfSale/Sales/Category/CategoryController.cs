using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Auth.Atributtes;
using PointOfSale.Shared.DTOs.Responses;

namespace PointOfSale.Sales.Category
{
    [Authorize]
    [PermissionAuthorize]
    [ApiController]
    [Route("api/product")]
    [Produces("application/json")]
    [ProducesResponseType(401)]
    [ProducesResponseType(404, Type = typeof(ErrorResponseDto))]
    public class CategoryController : ControllerBase
    {

    }
}
