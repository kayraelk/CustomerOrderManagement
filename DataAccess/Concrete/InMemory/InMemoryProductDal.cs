using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId=1, CategoryId=1, ProductName="Çanak", UnitPrice=12, UnitsInStock=30},
                new Product{ProductId=2, CategoryId=2, ProductName="Tabak", UnitPrice=12, UnitsInStock=35},
                new Product{ProductId=3, CategoryId=1, ProductName="Kabak", UnitPrice=15, UnitsInStock=30},
                new Product{ProductId=4, CategoryId=2, ProductName="Kaymak", UnitPrice=32, UnitsInStock=23},
                new Product{ProductId=5, CategoryId=1, ProductName="Bıçak", UnitPrice=21, UnitsInStock=12},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = null;

            //Without Linq
            //foreach(var item in _products)
            //{
            //    if(item.ProductId == product.ProductId)
            //    {
            //        productToDelete = item;
            //    }
            //}

            //LINQ - Language Integrated Query
            productToDelete = _products.SingleOrDefault(x => x.ProductId == product.ProductId);

            _products.Add(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(x => x.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(x => x.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
