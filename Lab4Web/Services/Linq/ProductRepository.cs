using System.Collections.Generic;

namespace Lab4Web.Services.Linq
{
    public static class ProductRepository
    {
        public static List<Product> Products { get; } = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1500, Category = "Electronics", InStock = true },
            new Product { Id = 2, Name = "Smartphone", Price = 800, Category = "Electronics", InStock = false },
            new Product { Id = 3, Name = "Headphones", Price = 100, Category = "Electronics", InStock = true },
            new Product { Id = 4, Name = "Chair", Price = 200, Category = "Furniture", InStock = true },
            new Product { Id = 5, Name = "Table", Price = 300, Category = "Furniture", InStock = false },
            new Product { Id = 6, Name = "Bookshelf", Price = 150, Category = "Furniture", InStock = true },
            new Product { Id = 7, Name = "Watch", Price = 250, Category = "Accessories", InStock = true },
            new Product { Id = 8, Name = "Sunglasses", Price = 80, Category = "Accessories", InStock = true },
            new Product { Id = 9, Name = "Backpack", Price = 120, Category = "Accessories", InStock = false },
            new Product { Id = 10, Name = "T-shirt", Price = 30, Category = "Clothing", InStock = true }
        };
    }
}
