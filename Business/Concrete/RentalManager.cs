using Business.Abstract;
using Business.Constance;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalsDal _rentalsDal;

        public RentalManager(IRentalsDal rentalsDal)
        {
            _rentalsDal = rentalsDal;
        }

        public IResult Add(Rentals rental)
        {
            var result = _rentalsDal.Get(x => x.CarId == rental.CarId && x.ReturnDate == null);
            if (result == null)
            {
                _rentalsDal.Add(rental);
                return new SuccessResult(Messages.Added);
            }
            return new ErrorResult(Messages.CarAlreadyRented);
        }

        public IResult Delete(Rentals rental)
        {

            _rentalsDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Rentals> Get(int id)
        {
            return new SuccessDataResult<Rentals>(_rentalsDal.Get(r => r.Id == id),Messages.ListedById);
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccessDataResult<List<Rentals>>(_rentalsDal.GetAll(),Messages.Listed);
        }

        public IResult Update(Rentals rental)
        {

            _rentalsDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
    }
}
