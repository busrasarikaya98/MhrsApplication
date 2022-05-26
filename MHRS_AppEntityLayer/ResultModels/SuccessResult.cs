using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationEntityLayer.ResultModels
{
    public class SuccessResult : Result
    {
        //en az 1 parametre almayı zorunlu tutuyor çünkü implemet class parametreli
        //İLK YOL İLK PARAMETRE
        public SuccessResult() : base(true)
        {
            //otomatik success kabul ediyor ve bunu true döndürüyor
            //dışarıdan parametreyi kabul etmez bu success ve truedur
            //errorresultda da otomatik success kabul edecek

        }
        //İKİNCİ YOL İKİNCİ PARAMETRE
        public SuccessResult(string message):base(true,message)
        {
            //dışardan mesaja izin var
        }
    }
}
