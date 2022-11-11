using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ID=1,BrandID=1,CarName="Audi",      DailyPrice=1500,    ColorID=15,          ModelYear=2015 },
                new Car{ID=2,BrandID=2,CarName="BMW",       DailyPrice=2000,    ColorID=10,          ModelYear=2018 },
                new Car{ID=3,BrandID=3,CarName="MERCEDES",  DailyPrice=3000,    ColorID=12,          ModelYear=2019 },
                new Car{ID=4,BrandID=4,CarName="JEEP",      DailyPrice=5000,    ColorID=19,          ModelYear=2008 },
                new Car{ID=5,BrandID=5,CarName="PASSAT",    DailyPrice=1000,    ColorID=20,          ModelYear=2016 },
                new Car{ID=6,BrandID=2,CarName="BMW",       DailyPrice=1560,    ColorID=55,          ModelYear=1999 },
                new Car{ID=7,BrandID=7,CarName="MUSTANG",   DailyPrice=5500,    ColorID=55,          ModelYear=1967 }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
           Car carToDelete=_cars.SingleOrDefault(c=>c.ID==car.ID);
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
            return _cars.ToList();
        }

        public List<Car> GetByBrand(int brandId)
        {
            return _cars.Where(c => c.BrandID==brandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate=_cars.SingleOrDefault(c=>c.ID==car.ID);
            carToUpdate.BrandID=car.BrandID;
            carToUpdate.Description=car.Description;
            carToUpdate.DailyPrice=car.DailyPrice;
            carToUpdate.ColorID=car.ColorID;
            carToUpdate.ModelYear=car.ModelYear;
            
        }
    }
}
