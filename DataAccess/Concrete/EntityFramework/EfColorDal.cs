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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (var dbContext = new CarsContext())
            {
                var addedEntity = dbContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                dbContext.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (var dbContext = new CarsContext())
            {
                var deletedEntity = dbContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                dbContext.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (var dbContext = new CarsContext())
            {
                return dbContext.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (var dbContext = new CarsContext())
            {
                return filter == null ?
                    dbContext.Set<Color>().ToList() :
                    dbContext.Set<Color>().Where(filter).ToList();
            }
        }

        public void Update(Color entity)
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
