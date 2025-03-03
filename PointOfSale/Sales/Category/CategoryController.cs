using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Auth.Atributtes;
using PointOfSale.Auth.Constants;
using PointOfSale.Models;
using PointOfSale.Sales.Category.DTOs.Request;
using PointOfSale.Sales.Category.DTOs.Response;
using PointOfSale.Sales.Category.Services;
using PointOfSale.Sales.Products.Services;
using PointOfSale.Shared.DTOs.Responses;

namespace PointOfSale.Sales.Category
{
    //[Authorize]
    //[PermissionAuthorize]
    [ApiController]
    [Route("api/product")]
    [Produces("application/json")]
    [ProducesResponseType(401)]
    [ProducesResponseType(404, Type = typeof(ErrorResponseDto))]
    public class CategoryController(ICategoryService categoryService, IProductService productService, IMapper mapper) : ControllerBase
    {
        private readonly ICategoryService _categoryService = categoryService;
        private readonly IProductService _productService = productService;

        private readonly IMapper _mapper = mapper;


        [HttpGet("{id}")]
        [PermissionPolicy(DefaultActions.Read, DefaultSubjects.Category)]
        public async Task<IActionResult> GetCategory(int id)
        {
            GetCategoryResponse? categoryResponse = await _categoryService.GetCategoryResponseByIdAsync(id);

            if (categoryResponse == null)
            {
                return NotFound("Category does not exist");
            }

            var res = new SuccessResponseDto { Data = categoryResponse };

            return Ok(res);
        }

        [HttpGet]
        [PermissionPolicy(DefaultActions.Read, DefaultSubjects.Category)]
        public async Task<IActionResult> GetCategories(GetCategoriesQueryParams queryParams)
        {
            List<GetCategoryResponse> categoryResponse = await _categoryService.GetCategoriesResponseAsync(queryParams);

            var res = new SuccessResponseDto { Data = categoryResponse };

            return Ok(res);
        }

        [HttpPost]
        [PermissionPolicy(DefaultActions.Create, DefaultSubjects.Category)]
        public async Task<IActionResult> CreateCategory([FromBody] CreateUpdateCategoryRequest createUpdate)
        {
            await _categoryService.CreateCategoryAsync(createUpdate);

            return Created();
        }

        [HttpPut("{id}")]
        [PermissionPolicy(DefaultActions.Update, DefaultSubjects.Category)]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CreateUpdateCategoryRequest createUpdate)
        {
            ProductCategory? category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound("Category Not Found");
            }

            category = _mapper.Map(createUpdate, category);


            await _categoryService.UpdateCategoryAsync(category);

            return NoContent();
        }


        [HttpPatch("{id}")]
        [PermissionPolicy(DefaultActions.Update, DefaultSubjects.Category)]
        [PermissionPolicy(DefaultActions.Update, DefaultSubjects.Products)]
        public async Task<IActionResult> AssingProductToCategory(int id, [FromBody] AssignProductsToCategoryRequest categoryRequest)
        {
            string[] productsIds = categoryRequest.ProductsIDs;
            ProductCategory? category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound("Category Not found");
            }
            List<ProductsItem> productsItems = await _productService.GetProductsItemsByIDsAsync(productsIds);

            if (productsItems.Count != productsIds.Length || productsItems.Count <= 0)
            {
                return BadRequest("Some or all products does not exist");
            }

            await _categoryService.AssignProductsToCategoryAsync(category, productsItems);


            return NoContent();
        }


        [HttpDelete("{id}/all")]
        [PermissionPolicy(DefaultActions.Delete, DefaultSubjects.Category)]
        [PermissionPolicy(DefaultActions.Delete, DefaultSubjects.Products)]
        public async Task<IActionResult> DeleteCategoryWithProducts(int id)
        {
            ProductCategory? category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound("Category Not Found");
            }


            await _categoryService.DeleteCategoryWithProductsAsync(category);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [PermissionPolicy(DefaultActions.Delete, DefaultSubjects.Category)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            ProductCategory? category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound("Category Not Found");
            }


            await _categoryService.DeleteCategoryAsync(category);

            return NoContent();
        }


    }
}
