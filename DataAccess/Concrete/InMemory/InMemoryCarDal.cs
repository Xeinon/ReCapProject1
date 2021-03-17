using DataAccess.Abstract;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> 
            {
                new Car {CarId = 1, BrandId = 1, DailyPrice = 100, Description = "Renault Clio", ColorId = 1, ModelYear = 2014,CarName = "Renault" },
                new Car {CarId = 2, BrandId = 2, DailyPrice = 120, Description = "Renault Megane", ColorId = 2, ModelYear = 2017,CarName = "Renault" },
                new Car {CarId = 1, BrandId = 1, DailyPrice = 150, Description = "Peugeot", ColorId = 1, ModelYear = 2018,CarName = "Renault" },
                new Car {CarId = 2, BrandId = 2, DailyPrice = 140, Description = "Opel Corsa", ColorId = 2, ModelYear = 2018,CarName = "Renault" },

            };       
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }
    }
}
