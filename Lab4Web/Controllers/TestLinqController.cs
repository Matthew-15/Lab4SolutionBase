using Lab4Web.Services.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Lab4Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestLinqController : ControllerBase
    {
        private readonly ILinqService _linqService;

        public TestLinqController(ILinqService linqService)
        {
            _linqService = linqService;
        }

        [HttpGet("products-by-category")]
        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _linqService.GetProductsByCategory(category);
        }

        [HttpGet("product-names")]
        public IEnumerable<string> GetProductNames()
        {
            return _linqService.GetProductNames();
        }

        [HttpGet("product-count")]
        public int GetProductCount(string category)
        {
            var products = _linqService.GetProductsByCategory(category);
            return _linqService.GetCountOfProducts(products);
        }

        [HttpGet("products-in-stock")]
        public IEnumerable<Product> GetProductsInStock()
        {
            return _linqService.GetProductsInStock();
        }

        [HttpGet("products-and-prices")]
        public IEnumerable<(string Name, decimal Price)> GetProductsAndPrices()
        {
            return _linqService.GetProductsAndPrices();
        }

        [HttpGet("group-products-by-category")]
        public IEnumerable<IGrouping<string, Product>> GroupProductsByCategory()
        {
            return _linqService.GroupProductsByCategory();
        }
    }
}
