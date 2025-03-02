using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using PointOfSale.Models;
using Xunit;

namespace PointOfSale.Sales.Products.Services
{
    public class ProductServiceTests
    {
        private readonly Mock<CorteDeCajaContext> _contextDb = new Mock<CorteDeCajaContext>();
        private readonly Mock<DbSet<ProductsItem>> _database = new Mock<DbSet<ProductsItem>>();
        private ProductService _service;

        public ProductServiceTests(IMapper mapper)
        {
            var products = new List<ProductsItem>{
            new ProductsItem { Name = "Product1" },
            new ProductsItem { Name = "Product2" }
            };
            _database.As<IQueryable<ProductsItem>>().Setup(m => m.Provider).Returns(products.AsQueryable().Provider);
            _database.As<IQueryable<ProductsItem>>().Setup(m => m.Expression).Returns(products.AsQueryable().Expression);
            _database.As<IQueryable<ProductsItem>>().Setup(m => m.ElementType).Returns(products.AsQueryable().ElementType);
            _database.As<IQueryable<ProductsItem>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());


            _contextDb.Setup(c => c.ProductsItems).Returns(_database.Object);

            _service = new ProductService(_contextDb.Object, mapper);
        }

        [Fact]
        public async Task GetProductsItemsAsync_ShouldReturnTheDataIsRequired()
        {
            // Act

            // Assert

        }


    }
}
