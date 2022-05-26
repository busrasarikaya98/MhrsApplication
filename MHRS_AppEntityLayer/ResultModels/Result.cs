﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationEntityLayer.ResultModels
{
    public class Result : IResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Result(bool success)
        {
            IsSuccess = success;
        }
        public Result(bool success,string message):this(success)
        {
            //IsSuccess = success;
            Message = message;
        }
    }
}
