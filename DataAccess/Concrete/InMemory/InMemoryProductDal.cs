using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            // In-memory database simulation
            _products = new List<Product>
            {
                new Product { ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitsInStock = 15, UnitPrice = 15 },
                new Product { ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitsInStock = 3, UnitPrice = 500 },
                new Product { ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitsInStock = 2, UnitPrice = 1500 },
                new Product { ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitsInStock = 65, UnitPrice = 150 },
                new Product { ProductId = 5, CategoryId = 2, ProductName = "Fare", UnitsInStock = 1, UnitPrice = 85 }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = null;
            foreach (var p in _products)
            {
                if (p.ProductId == product.ProductId)
                {
                    productToDelete = p;
                    break;
                }
            }
            if (productToDelete != null)
            {
                _products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }

            /* Alternatively,
             * productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
             * LINQ can be used to find the product to delete
             * LINQ = Language Integrated Query
             * => is a lambda expression operator
             */
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=>p.CategoryId == categoryId).ToList();

        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
