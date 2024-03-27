using System.Collections.Generic;
using System.Linq;

namespace Lab4Web.Services.Linq
{

    public class Student
    {
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class LinqService : ILinqService
    {
        public List<Student> students = new List<Student>()
        {
            new Student("T1", 25),
            new Student("T2", 29),
            new Student("T3", 33),
        };

        public int Test1(int value)
        {
            return students.Count(student => student.Age >= value);
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return ProductRepository.Products.Where(p => p.Category == category);
        }

        public IEnumerable<string> GetProductNames()
        {
            return ProductRepository.Products.Select(p => p.Name);
        }

        public IEnumerable<Product> GetProductsInStock()
        {
            return ProductRepository.Products.Where(p => p.InStock);
        }

        public IEnumerable<(string Name, decimal Price)> GetProductsAndPrices()
        {
            return ProductRepository.Products.Join(
                ProductRepository.Products,
                p1 => p1.Name,
                p2 => p2.Name,
                (p1, p2) => (p1.Name, p2.Price)
            );
        }

        public IEnumerable<IGrouping<string, Product>> GroupProductsByCategory()
        {
            return ProductRepository.Products.GroupBy(p => p.Category);
        }

        public int GetCountOfProducts(IEnumerable<Product> products)
        {
            return products.Count();
        }
    }
}
