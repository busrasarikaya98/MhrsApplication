using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationEntityLayer.ResultModels
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data) : base(data, false)
        {
            //Tyi bilmediği için dışardan T verilir
        }

        public ErrorDataResult(T data,string message) : base(data, false, message)
        {
            //bunun adı error adından anlayıp bu bir errordur der ve false değeri
        }
    }
}
