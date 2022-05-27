using MHRS_ApplicationEntityLayer.ResultModels;
using MHRS_ApplicationEntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationBusinessLayer.Abstracts
{
    public interface IAppointmentService
    {
        //Geçmiş ve iptal Randevuları getir
        /// <summary>
        /// Bu metot hastaya ait geçmiş ve iptal randevuları getirir
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        IDataResult<ICollection<AppointmentViewModel>> GetPastandCancelledAppointments(string patientId);

        //Aktif ranndevular
        /// <summary>
        /// Bu metot hastaya ait aktif randevuları getirir
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        IDataResult<ICollection<AppointmentViewModel>> GetUpComingAppoinments(string patientId);


        //idlere göre appointmetn getir
        /// <summary>
        ///  Bu metot kendisine gönderilen hastaya, hastaneye, kliniğe, randevu tarihine ve saatine göre data çeker.
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="hospitalClinicId"></param>
        /// <param name="appointmentDate"></param>
        /// <param name="appointmentHour"></param>
        /// <returns></returns>
        IDataResult<AppointmentViewModel> GetAppointmentByIDs(string patientId, int hospitalClinicId, DateTime appointmentDate, string appointmentHour);

    }

}
