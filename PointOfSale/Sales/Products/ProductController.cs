using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Auth.Atributtes;
using PointOfSale.Auth.Constants;
using PointOfSale.Models;
using PointOfSale.Sales.Products.DTOs.Request;
using PointOfSale.Sales.Products.Services;
using PointOfSale.Shared.DTOs.Responses;

namespace PointOfSale.Sales.Products
{
    [Authorize]
    [PermissionAuthorize]
    [ApiController]
    [Route("api/product")]
    [Produces("application/json")]
    [ProducesResponseType(401)]
    [ProducesResponseType(404, Type = typeof(ErrorResponseDto))]
    public class ProductController(IProductService productService, IMapper mapper) : ControllerBase
    {
        private readonly IProductService _productService = productService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [PermissionPolicy(DefaultActions.Read, DefaultSubjects.Products)]
        public async Task<IActionResult> GetProducts([FromQuery] GetProductsQueryParams queryParams)
        {
            List<ProductsItem> products = await _productService.GetProductItemsAsync(queryParams);

            SuccessResponseDto response = new() { Data = products };
            return Ok(response);
        }

        [HttpGet("{barcode}")]
        [PermissionPolicy(DefaultActions.Read, DefaultSubjects.Products)]
        public async Task<IActionResult> GetProduct(string barcode)
        {
            ProductsItem? product = await _productService.GetProductItemByBarCodeAsync(barcode);

            if (product == null)
            {
                return NotFound(new ErrorResponseDto { Title = "Product not found" });
            }

            SuccessResponseDto response = new() { Data = product };
            return Ok(response);
        }


        [HttpPost]
        [PermissionPolicy(DefaultActions.Create, DefaultSubjects.Products)]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductItem product)
        {
            await _productService.CreateProductItemAsync(product);
            return Ok();
        }

        [HttpPut("{barcode}")]
        [PermissionPolicy(DefaultActions.Update, DefaultSubjects.Products)]
        public async Task<IActionResult> UpdateProduct(string barcode, [FromBody] UpdateProductItem product)
        {
            ProductsItem? p = await _productService.GetProductItemByBarCodeAsync(barcode);

            if (p == null)
            {
                return NotFound("Product not found");
            }

            _mapper.Map<ProductsItem>(p);

            await _productService.UpdateProductItemAsync(p);

            return NoContent();
        }

        [HttpDelete("{barcode}")]
        [PermissionPolicy(DefaultActions.Delete, DefaultSubjects.Products)]
        public async Task<IActionResult> DeleteProduct(string barcode)
        {

            ProductsItem? p = await _productService.GetProductItemByBarCodeAsync(barcode);


            if (p == null)
            {
                return NotFound("Product not found");
            }

            await _productService.DeleteProductItemAsync(p);

            return Ok();

        }

    }
}
