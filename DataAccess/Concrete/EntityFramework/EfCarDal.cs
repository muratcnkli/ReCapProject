using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RecapProjectContext context=new RecapProjectContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandID equals brand.BrandId
                             join color in context.Colors on car.ColorID equals color.ColorID
                             select new CarDetailDto 
                             {
                                 CarName=car.CarName,
                                 BrandName=brand.BrandName,
                                 ColorName=color.ColorName,
                                 DailyPrice=car.DailyPrice,


                             };
                return result.ToList();

            }
        }
    }
}
