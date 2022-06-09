﻿using MHRS_ApplicationDataAccessLayer.Abstracts;
using MHRS_ApplicationEntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationDataAccessLayer.Concretes
{
    public class DenemeRepository:BaseRepository<Deneme,int>,IDenemeRepository
    {
        public DenemeRepository(MyContext myContext):base(myContext)
        {

        }
    }
}
