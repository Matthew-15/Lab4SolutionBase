using System.Collections.Generic;

namespace Lab4Web.Services.Linq
{
    public interface ILinqService
    {
        IEnumerable<Product> GetProductsByCategory(string category);

        IEnumerable<string> GetProductNames();

        int GetCountOfProducts(IEnumerable<Product> products);

        IEnumerable<Product> GetProductsInStock();

        IEnumerable<(string Name, decimal Price)> GetProductsAndPrices();

        IEnumerable<IGrouping<string, Product>> GroupProductsByCategory();
    }
}
