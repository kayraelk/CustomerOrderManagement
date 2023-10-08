﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDisposable pattern implementation of C#
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); //Entity nin referansı yakalandı.
                addedEntity.State = EntityState.Added; //Referansı yakalanan entity ye hangi işilemin yapılacağı seçildi.
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity); //Entity nin referansı yakalandı.
                deletedEntity.State = EntityState.Deleted; //Referansı yakalanan entity ye hangi işilemin yapılacağı seçildi.
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            //using (NorthwindContext context = new NorthwindContext())
            //{
            //    //return context.Set<Product>().Where(filter).ToList();
            //}
            return null;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity); //Entity nin referansı yakalandı.
                updatedEntity.State = EntityState.Modified; //Referansı yakalanan entity ye hangi işilemin yapılacağı seçildi.
                context.SaveChanges();
            }
        }
    }
}
