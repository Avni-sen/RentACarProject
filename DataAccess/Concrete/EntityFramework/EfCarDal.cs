using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car car)
        {
            using (RentACarContext context = new())
            {
                var addedCar = context.Entry(car);
                addedCar.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car car)
        {
            using (RentACarContext context = new())
            {
                var deletedCar = context.Entry(car);
                deletedCar.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RentACarContext context = new())
            {
                return context.Set<Car>().Where(filter).SingleOrDefault();
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter)
        {
            using (RentACarContext context = new())
            {

                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();


            }
        }

        public void Update(Car car)
        {
            using (RentACarContext context = new())
            {
                var updatedCar = context.Entry(car);
                updatedCar.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
