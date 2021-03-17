using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Entities;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());


            brandManager.Add(new Brand { BrandId = 1, BrandName = "Renault" });
            brandManager.Add(new Brand { BrandId = 2, BrandName = "Opel" });
            brandManager.Add(new Brand { BrandId = 1, BrandName = "Peugeot" });
            brandManager.Add(new Brand { BrandId = 2, BrandName = "Ford" });

            colorManager.Add(new Color { ColorId = 1, ColorName = "Kırmızı" });
            colorManager.Add(new Color { ColorId = 2, ColorName = "Mavi" });
            colorManager.Add(new Color { ColorId = 3, ColorName = "Siyah" });
            colorManager.Add(new Color { ColorId = 3, ColorName = "Beyaz" });



            carManager.Add(new Car { CarId = 1, BrandId = 1, DailyPrice = 100, Description = "Kirada", ColorId = 1, ModelYear = 2014, CarName = "Renault" });
            carManager.Add(new Car { CarId = 2, BrandId = 2, DailyPrice = 120, Description = "Uygun", ColorId = 2, ModelYear = 2017, CarName = "Opel" });
            carManager.Add(new Car { CarId = 3, BrandId = 1, DailyPrice = 150, Description = "Kirada", ColorId = 1, ModelYear = 2018, CarName = "Peugeot" });
            carManager.Add(new Car { CarId = 4, BrandId = 2, DailyPrice = 140, Description = "Uygun", ColorId = 2, ModelYear = 2018, CarName = "Ford" });


            foreach (var result in carManager.GetAll())
            {
                Console.WriteLine(result.ModelYear);
            }
            Console.WriteLine("-------------*-------------");
            foreach (var result2 in brandManager.GetAll())
            {
                Console.WriteLine(result2.BrandName);
            }
            Console.WriteLine("---------------------------");

            foreach (var result3 in colorManager.GetAll())
            {
                Console.WriteLine(result3.ColorName);
            }
            Console.WriteLine("-------------*-------------");

            foreach (var result4 in carManager.GetByAllBrandId(2))
            {

                Console.WriteLine(result4.ModelYear);

            }


        }
                
    }        
}
