using MHRS_ApplicationDataAccessLayer.Abstracts;
using MHRS_ApplicationEntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationDataAccessLayer.Concretes
{
    public class HospitalRepository : BaseRepository<Hospital, int>, IHospitalRepository
    {
        public HospitalRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
