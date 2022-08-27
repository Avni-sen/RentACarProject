using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>,ICarDal
    {
       

        public List<CarDetailDto> GetCarDetailDtos()
        {
            using (RentACarContext context = new())
            {
                var result = from x in context.Cars
                             join c in context.Colors
                             on x.ColorId equals c.Id
                             join b in context.Brands
                             on x.BrandId equals b.Id
                             select new CarDetailDto { Id = x.Id, BrandName = b.BrandName, ColorName = c.ColorName };
                return result.ToList();
            }
        }
    }
}
