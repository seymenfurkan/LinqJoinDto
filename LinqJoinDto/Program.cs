using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>
           {
               new Category{CategoryId = 1 , CategoryName = "Telefon"},
               new Category{CategoryId = 2 , CategoryName = "Bilgisayar"},
               new Category{CategoryId = 3 , CategoryName = "Kulaklık"}
           };
            List<Product> products = new List<Product>
            {
                new Product{ProductId = 1 , CategoryId = 1 , ProductName = "iPhone 13 Pro MAX", QuantityPerUnit = "APPLE's Phone", UnitPrice = 32000, UnitsInStock= 12},
                new Product{ProductId = 2 , CategoryId = 1 , ProductName = "Samsung S22 Ultra", QuantityPerUnit = "SAMSUNG's Phone", UnitPrice = 23000, UnitsInStock= 14},
                new Product{ProductId = 3 , CategoryId = 2 , ProductName = "Apple MacBook Pro", QuantityPerUnit = "APPLE's Computer", UnitPrice = 44000, UnitsInStock= 6},
                new Product{ProductId = 4 , CategoryId = 2 , ProductName = "HP Omen 17", QuantityPerUnit = "HP's Computer", UnitPrice = 23000, UnitsInStock= 10},
                new Product{ProductId = 5 , CategoryId = 3 , ProductName = "Beats Solo 3", QuantityPerUnit = "Beats's HeadPhone", UnitPrice = 3000, UnitsInStock= 99},
            };

            // GetProducts(products);

            //AnyTest(products);

            //FindTest(products);

            // WhereTest(products);

            //WhereASCDESCORDERBY(products);

            var result = from p in products
                         join c in categories
      on p.CategoryId equals c.CategoryId
                         orderby p.ProductName ascending
                         orderby c.CategoryName ascending
                         select new ProductDto { ProductId = p.ProductId, ProductName = p.ProductName, UnitPrice = p.UnitPrice, CategoryName = c.CategoryName };
            foreach (var product in result)
            {
                Console.WriteLine("{0} ---- {1}", product.ProductName, product.CategoryName);
            }
        }

        private static void WhereASCDESCORDERBY(List<Product> products)
        {
            var result = products.Where(p => p.QuantityPerUnit.Contains("APPLE")).OrderBy(p => p.UnitPrice).ThenBy(p => p.CategoryId).ToList();
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void WhereTest(List<Product> products)
        {
            var result = products.Where(p => p.UnitPrice < 30000 && p.CategoryId == 1).ToList();
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void FindTest(List<Product> products)
        {
            //Tek bir ürün döner
            var result = products.Find(p => p.CategoryId == 5);
            Console.WriteLine(result.ProductName);
        }

        private static void AnyTest(List<Product> products)
        {
            var result = products.Any(p => p.UnitsInStock > 10 && p.CategoryId == 1);
            Console.WriteLine(result);
        }

        static List<Product> GetProducts(List<Product> products)
        {
            var result = products.Where(p => p.UnitsInStock < 100).ToList();
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
            return result;
        }
    }
    class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string CategoryName { get; set; }
    }

    class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }

    class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
