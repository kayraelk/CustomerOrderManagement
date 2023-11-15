using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        // Bir iş sınıfı başa sınıfları newlemez. Constructor ile Dependency Injection yapılacaktır.
        //Soyut nesneyle bağıntı eklenecektir. Ne InMemory ne EntityFramework geçecektir.

        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IDataResult<List<Product>> GetAll()
        {
            if(DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id),Messages.ProductsListed);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDto>> GetProducts()
        {
            if (DateTime.Now.Hour == 13)
            {
                return new ErrorDataResult<List<ProductDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDto>>(_productDal.GetProducts());
        }

        public IResult Add(Product product)
        {
            if(product.ProductName.Length < 2)
            {
                //magic strings
                return new ErrorResult(Messages.ProductNameInvalid);
            }

            _productDal.Add(product);
            return new SucccessResult(Messages.ProductAdded);
        }
    }
}
