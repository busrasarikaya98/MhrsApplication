using AutoMapper;
using MHRS_ApplicationEntityLayer.Models;
using MHRS_ApplicationEntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationEntityLayer.Mappings
{
    public class Maps:Profile
    {
        public Maps()
        {
            //appointment nesnesini viewmodele,viewmodeli nesneye dönüştürdü
            CreateMap<Appointment, AppointmentViewModel>().ReverseMap();
            CreateMap<City, CityViewModel>().ReverseMap(); 
            CreateMap<District, DistrictViewModel>().ReverseMap();
            CreateMap<Hospital, HospitalViewModel>().ReverseMap();
            CreateMap<Clinic, ClinicViewModel>().ReverseMap();
            CreateMap<HospitalClinic, HospitalClinicViewModel>().ReverseMap();
            CreateMap<AppointmentHour, AppointmentHourViewModel>().ReverseMap();
        }
    }
}
