using MHRS_ApplicationDataAccessLayer.Abstracts;
using MHRS_ApplicationEntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationDataAccessLayer.Concretes
{
    public class AppointmentRepository : BaseRepository<Appointment, int>, IAppointmentRepository
    {
        public AppointmentRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
