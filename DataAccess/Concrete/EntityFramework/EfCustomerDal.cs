using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer,RentACarContext>,ICustomerDal
    {
        public List<CustomerDetailsDto> GetCustomerDetailDtos()
        {
            using (RentACarContext context = new())
            {
                var result = from x in context.Users
                             join c in context.Customers
                             on x.Id equals c.Id
                             select new CustomerDetailsDto { Id = c.Id , CompanyName=c.CompanyName , UserName=x.FirstName,UserLastname=x.LastName , Email=x.Email , Password =x.Password };
                return result.ToList();
            }
            
        }
    }
}
