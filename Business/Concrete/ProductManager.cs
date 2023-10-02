using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }
    }
}
