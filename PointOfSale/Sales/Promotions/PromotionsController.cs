using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Models;
using PointOfSale.Sales.Products.Services;
using PointOfSale.Sales.Promotions.DTOs.Request;
using PointOfSale.Sales.Promotions.DTOs.Response;
using PointOfSale.Sales.Promotions.Services;
using PointOfSale.Shared.DTOs.Responses;
using Swashbuckle.AspNetCore.Annotations;

namespace PointOfSale.Sales.Promotions
{
    //[Authorize]
    //[PermissionAuthorize]
    [ApiController]
    [Route("api/promotions")]
    [Produces("application/json")]
    public class PromotionsController(IPromotionService promotionService, IProductService productService, IMapper mapper) : ControllerBase
    {
        private readonly IPromotionService _promotionService = promotionService;
        private readonly IProductService _productService = productService;

        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Obtiene una lista de promociones según los parámetros de consulta.
        /// </summary>
        /// <param name="queryParams">Parámetros de consulta para filtrar las promociones.</param>
        /// <returns>Una lista de promociones</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Obtener todas las promociones", Description = "Devuelve una lista de promociones según los parámetros proporcionados.")]
        [SwaggerResponse(200, "Operación exitosa", typeof(SuccessResponseDto))]
        [SwaggerResponse(400, "Solicitud incorrecta")]
        public async Task<IActionResult> GetPromotions([FromQuery] GetPromotionsQueryParams queryParams)
        {
            List<PromotionResponse> promotions = await _promotionService.GetPromotionsResponse(queryParams);
            var res = new SuccessResponseDto { Data = promotions };

            return Ok(res);
        }

        /// <summary>
        /// Obtiene los detalles de una promoción específica por su ID.
        /// </summary>
        /// <param name="id">ID de la promoción</param>
        /// <returns>Detalles de la promoción</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtener una promoción por ID", Description = "Devuelve los detalles de una promoción específica según su ID.")]
        [SwaggerResponse(200, "Operación exitosa", typeof(SuccessResponseDto))]
        [SwaggerResponse(404, "Promoción no encontrada")]
        public async Task<IActionResult> GetPromotion(int id)
        {
            PromotionResponse? promotion = await _promotionService.GetPromotionResponseById(id);

            if (promotion == null) return NotFound();

            var res = new SuccessResponseDto { Data = promotion };

            return Ok(res);
        }

        /// <summary>
        /// Crea una nueva promoción.
        /// </summary>
        /// <param name="request">Datos necesarios para crear una nueva promoción.</param>
        /// <returns>Estado de la creación de la promoción</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Crear una nueva promoción", Description = "Permite crear una nueva promoción.")]
        [SwaggerResponse(201, "Promoción creada exitosamente")]
        [SwaggerResponse(400, "Datos de solicitud inválidos")]
        public async Task<IActionResult> CreatePromotion([FromBody] CreatePromotionRequest request)
        {
            Promotion promotionToCreate = _mapper.Map<Promotion>(request);

            await _promotionService.CreatePromotion(promotionToCreate);

            return CreatedAtAction(nameof(GetPromotion), new { id = promotionToCreate.Id }, null);
        }

        /// <summary>
        /// Actualiza una promoción existente.
        /// </summary>
        /// <param name="id">ID de la promoción a actualizar</param>
        /// <param name="request">Datos a actualizar</param>
        /// <returns>Estado de la actualización de la promoción</returns>
        [HttpPatch("{id}")]
        [SwaggerOperation(Summary = "Actualizar una promoción", Description = "Actualiza los detalles de una promoción existente.")]
        [SwaggerResponse(204, "Promoción actualizada exitosamente")]
        [SwaggerResponse(400, "Datos inválidos para la actualización")]
        [SwaggerResponse(404, "Promoción no encontrada")]
        public async Task<IActionResult> UpdatePromotion(int id, [FromBody] UpdatePromotionRequest request)
        {
            Promotion? promotionToUpdate = await _promotionService.GetPromotionById(id);

            if (promotionToUpdate == null) return NotFound($"Promotion with ID {id} not found");

            promotionToUpdate = _mapper.Map(request, promotionToUpdate);

            string[]? productsIDs = request.ProductsIDs;
            if (productsIDs != null && productsIDs.Length > 0)
            {
                List<ProductsItem> productsToAssing = await _productService.GetProductsItemsByIDsAsync(productsIDs);

                if (!productsToAssing.Any())
                {
                    return NotFound("Products does not exist");
                }

                if (productsToAssing.Count != productsIDs.Length)
                {
                    return NotFound("Some products does not exists");
                }

                promotionToUpdate.ProductBarcodes = productsToAssing;


                return NoContent();
            }

            await _promotionService.UpdatePromotion(promotionToUpdate);

            return NoContent();
        }

        /// <summary>
        /// Elimina una promoción existente.
        /// </summary>
        /// <param name="id">ID de la promoción a eliminar</param>
        /// <returns>Estado de la eliminación de la promoción</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Eliminar una promoción", Description = "Elimina una promoción existente por su ID.")]
        [SwaggerResponse(204, "Promoción eliminada exitosamente")]
        [SwaggerResponse(404, "Promoción no encontrada")]
        public async Task<IActionResult> DeletePromotion(int id)
        {
            Promotion? promotionToDelete = await _promotionService.GetPromotionById(id);

            if (promotionToDelete == null) return NotFound();

            await _promotionService.DeletePromotion(promotionToDelete);

            return NoContent();
        }
    }
}
