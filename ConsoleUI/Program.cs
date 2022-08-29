using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //carTest();

            // colorTest();
            //CustomerAdd();
            CustomerDetails();
            Console.ReadLine();
        }

        private static void colorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color();
            color.ColorName = "Mor";
            var result = colorManager.Add(color);
            if (result.Success)
            {
                    Console.WriteLine(result.Message);
            }
           
            
        }

        private static void carTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAll();
            if (result.Success)
            {
                foreach (var x in result.Data )
                {
                    Console.WriteLine(x.Description);
                }
            }
          
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalsDal());
            var result = rentalManager.Add(new Rentals { CustomerId = 1, CarId = 2, RentDate = new DateTime(2022, 08, 19, 11, 15, 00) });
            Console.WriteLine(result.Message);
        }

        private static void CustomerDetails()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetCustomerDetailDtos();

                if (result.Success)
                {
                foreach (var x in result.Data)
                {
                    Console.WriteLine(x.UserName+" " + x.UserLastname + " " + x.CompanyName + " " + x.Email + " " + x.Password);
                    Console.WriteLine();
                }
                Console.WriteLine(result.Message);
            }
      
        }

        private static void CustomerAdd()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            var result = customerManager.Add(new Customer
            { UserId = 2, CompanyName = "Real Solution" }

            );

            if (result.Success)
            {
                Console.WriteLine(result.Message);
            } 

        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.Add(new User
            {
                FirstName ="Emre ",
                LastName="ŞEN",
                Email="senemre35@gmail.com",
                Password="124gdhg3"
            });
            
            if (result.Success)
            {
                  Console.WriteLine(result.Message);
            }
        }

    }
}
