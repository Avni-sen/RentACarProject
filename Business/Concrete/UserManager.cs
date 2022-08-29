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
    public class UserManager : IUserService
    {

        IUserDal _userdal;

        public UserManager(IUserDal userdal)
        {
            _userdal = userdal;
        }


        public IResult Add(User user)
        {
            _userdal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(User user)
        {

            _userdal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<User> Get(int id)
        {
            return new SuccessDataResult<User>(_userdal.Get(p => p.Id == id), Messages.ListedById);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userdal.GetAll(), Messages.Listed);
        }

        public IResult Update(User user)
        {
            _userdal.Add(user);
            return new SuccessResult(Messages.Updated);
        }
    }
}
