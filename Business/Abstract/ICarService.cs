using DataAccess.Abstract;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        Car GetById(int carId);
        List<Car> GetAll();
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        List<Car> GetByAllBrandId(int brandId);
        List<Car> GetByAllColorId(int colorId);
        List<Car> GetByDailyPrice(decimal min, decimal max);


    }
}
