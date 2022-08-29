using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rentals>> GetAll();
        IDataResult<Rentals> Get(int id);
        IResult Add(Rentals rental);
        IResult Update(Rentals rental);
        IResult Delete(Rentals rental);
    }
}
