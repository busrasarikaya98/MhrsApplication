using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationDataAccessLayer.Abstracts
{
    public interface IUnitOfWork:IDisposable
    {
        //bütün repoları tek bir yerde toplamak amacıyla yazılır
        ICityRepository CityRepository { get; }
        IDistrictRepository DistrictRepository { get; }
        IClinicRepository ClinicRepository { get; }
        IHospitalRepository HospitalRepository { get; }
        IHospitalClinicRepository HospitalClinicRepository { get; }
        IAppointmentHourRepository AppointmentHourRepository { get; }
        IAppointmentRepository AppointmentRepository { get; }
        object HospitalClinicRepo { get; }
    }
}
