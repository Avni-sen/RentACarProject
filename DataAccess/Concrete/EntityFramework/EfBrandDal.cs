using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand brand)
        {
            using (RentACarContext context = new())
            {
                var addedBrand = context.Entry(brand);
                addedBrand.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand brand)
        {
            using (RentACarContext context = new())
            {
                var deletedBrand = context.Entry(brand);
                deletedBrand.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (RentACarContext context = new())
            {
                return context.Set<Brand>().Where(filter).SingleOrDefault();
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter)
        {
            using (RentACarContext context = new())
            {

                return filter == null ? context.Set<Brand>().ToList() : context.Set<Brand>().Where(filter).ToList();


            }
        }

        public void Update(Brand brand)
        {
            using (RentACarContext context = new())
            {
                var updatedCar = context.Entry(brand);
                updatedCar.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
