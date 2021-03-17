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
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (var dbContext = new CarsContext())
            {
                var addedEntity = dbContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                dbContext.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (var dbContext = new CarsContext())
            {
                var deletedEntity = dbContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                dbContext.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (var dbContext = new CarsContext())
            {
                return dbContext.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (var dbContext = new CarsContext())
            {
                return filter == null ?
                    dbContext.Set<Car>().ToList() :
                    dbContext.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
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
