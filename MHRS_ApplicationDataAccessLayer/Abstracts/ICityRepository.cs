﻿using MHRS_ApplicationEntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationDataAccessLayer.Abstracts
{
    public interface ICityRepository:IBaseRepository<City,byte> //bunun idsi byte yaptık
    {
    }
}
