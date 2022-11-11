using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Drawing;

namespace ConseleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CarOfADD();
            //CarOfDELETE();
            //CarTestOfBrandId();
            //CarTestOfGetDetails();
            //BrandOfGetAll();
            ColorOfGetAll();
            //CustomerOfGetAll();
            //RentalOfGetAll();
            //RentalOfAdd();
            //RentalOfGetAll();


        }

        private static void RentalOfAdd()
        {
            Rental rental = new Rental();
            rental.CarId = 4;
            rental.CustomerId = "muratcnkli";
            rental.RentDate = DateTime.Now;
            rental.ReturnDate = DateTime.Parse("2022-12-12");
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(rental);
        }

        private static void RentalOfGetAll()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine($"{rental.CustomerId} {rental.CarId}");
            }
        }

        private static void CustomerOfGetAll()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            foreach (var c in customerManager.GetAll().Data)
            {
                Console.WriteLine($"{c.CustomerID}  {c.CompanyName}");
            }
            //UserOfGetAll();
        }

        private static void UserOfGetAll()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine($"{user.FirstName} {user.LastName}");
            }
        }

        private static void ColorOfGetAll()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine($"{color.ColorID} {color.ColorName}");
            }
        }

        private static void BrandOfGetAll()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine($"{brand.BrandId}  {brand.BrandName}");
            }
        }

        private static void CarOfDELETE()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car { ID = 3 });
            
        }

        private static void CarOfADD()
        {
            Car car = new Car();
            car.BrandID = 5;
            car.CarName = "Focus";
            car.ColorID = 2;
            car.DailyPrice = 1000;
            car.ModelYear = 2018;
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car);
        }

        private static void CarTestOfBrandId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByBrandId(1).Data)
            {

                Console.WriteLine(car.CarName);
            }
        }
         private static void CarTestOfGetDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine($"{car.BrandName}  {car.CarName}  {car.ColorName} {car.DailyPrice}");
            }
        }
    }
}
