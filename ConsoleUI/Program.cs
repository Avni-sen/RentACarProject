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

            colorTest();

            Console.ReadLine();
        }

        private static void colorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color();
            color.ColorName = "Mor";
            colorManager.Add(color);
            foreach (var x in colorManager.GetColors())
            {
                Console.WriteLine(x.ColorName);
            }
            
        }

        private static void carTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
