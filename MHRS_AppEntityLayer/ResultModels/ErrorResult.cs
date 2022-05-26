using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationEntityLayer.ResultModels
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(false)
        {
            //dışardan müdahaleyi kapatıyor sen falsesın
        }
        public ErrorResult(string message) : base(false,message)
        {
            //dışardan müdahale açık sen falsesın mesajın bu
        }
    }
}
