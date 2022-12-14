using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            
             _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();

        }

        public IDataResult <List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult <List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult <List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(p=>p.BrandID==brandId));
        }

        public IDataResult <List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(p=>p.ColorID==colorId));
        }

        public IResult  Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();

        }
    }
}
