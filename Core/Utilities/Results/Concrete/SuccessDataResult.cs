using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {
        }
        public SuccessDataResult(T data, bool success) : base(data, success)
        {
        }

        //burdan aşağısını genelde kullanılmaz kabul ediyoruz
        public SuccessDataResult(string message) : base(default, true, message)
        {

        }

        //default dataya karşılı geliyor 
        public SuccessDataResult() : base(default, true)
        {

        }

    }
}
