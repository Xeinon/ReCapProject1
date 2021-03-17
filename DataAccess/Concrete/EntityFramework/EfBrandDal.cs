using DataAccess.Abstract;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (var dbContext = new CarsContext())
            {
                var addedEntity = dbContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                dbContext.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (var dbContext = new CarsContext())
            {
                var deletedEntity = dbContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                dbContext.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (var dbContext = new CarsContext())
            {
                return dbContext.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (var dbContext = new CarsContext())
            {
                return filter == null ?
                    dbContext.Set<Brand>().ToList() :
                    dbContext.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand entity)
        {
            using (var dbContext = new CarsContext())
            {
                var updatedEntity = dbContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }
    }
}
