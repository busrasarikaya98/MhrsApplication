using AutoMapper;
using MHRS_ApplicationBusinessLayer.Abstracts;
using MHRS_ApplicationDataAccessLayer.Abstracts;
using MHRS_ApplicationEntityLayer.Enums;
using MHRS_ApplicationEntityLayer.Models;
using MHRS_ApplicationEntityLayer.ResultModels;
using MHRS_ApplicationEntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationBusinessLayer.Concretes
{
    public class AppointmentManager : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AppointmentManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IDataResult<AppointmentViewModel> GetAppointmentByIDs(string patientId, int hospitalClinicId, DateTime appointmentDate, string appointmentHour)
        {
            try
            {
                var appointment = _unitOfWork.AppointmentRepository
                    .GetFirstOrDefault(x => x.PatientId == patientId
                    &&
                    x.HospitalClinicId == hospitalClinicId
                    && x.AppointmentDate == appointmentDate
                    && x.AppointmentHour == appointmentHour,
                    includeEntities: "HospitalClinic,Patient");
                if (appointment == null)
                {
                    throw new Exception("HATA: Randevu bulunamadı!");
                }

                //hastane
                appointment.HospitalClinic.Hospital =
                    _unitOfWork.HospitalRepository.GetById(appointment.HospitalClinic.HospitalId);
                //klinik
                appointment.HospitalClinic.Clinic =
                    _unitOfWork.ClinicRepository.GetById(appointment.HospitalClinic.ClinicId);
                //ilçe
                appointment.HospitalClinic.Hospital.HospitalDistrict =
                    _unitOfWork.DistrictRepository.GetById(appointment.HospitalClinic.Hospital.DistrictId);
                //il
                appointment.HospitalClinic.Hospital.HospitalDistrict.City =
                    _unitOfWork.CityRepository.GetById(appointment.HospitalClinic.Hospital.HospitalDistrict.CityId);

                var data = _mapper.Map<Appointment, AppointmentViewModel>(appointment);
                return new SuccessDataResult<AppointmentViewModel>(data);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IDataResult<ICollection<AppointmentViewModel>> GetPastandCancelledAppointments(string patientId)
        {
            try
            {
                //select * from Appoinments where PatientId,AppointmentStatus
                //inner join HospitalClinic,Patient
                var appointments = _unitOfWork.AppointmentRepository.
                    GetAll(x => x.PatientId == patientId
                    && x.AppointmentStatus != AppointmentStatus.Active, // geçmiş ve iptaller
                    includeEntities: "HospitalClinic,Patient");

                foreach (var item in appointments)
                {
                    //hastane
                    item.HospitalClinic.Hospital =
                        _unitOfWork.HospitalRepository.GetById(item.HospitalClinic.HospitalId);
                    //klinik
                    item.HospitalClinic.Clinic =
                        _unitOfWork.ClinicRepository.GetById(item.HospitalClinic.ClinicId);
                    //ilçe
                    item.HospitalClinic.Hospital.HospitalDistrict =
                        _unitOfWork.DistrictRepository.GetById(item.HospitalClinic.Hospital.DistrictId);
                    //il
                    item.HospitalClinic.Hospital.HospitalDistrict.City =
                        _unitOfWork.CityRepository.GetById(item.HospitalClinic.Hospital.HospitalDistrict.CityId);
                }

                var data = _mapper.Map<IQueryable<Appointment>, ICollection<AppointmentViewModel>>(appointments);

                return new SuccessDataResult<ICollection<AppointmentViewModel>>(data);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public IDataResult<ICollection<AppointmentViewModel>> GetUpComingAppoinments(string patientId)
        {
            try
            {
                //select * from Appoinments where PatientId,AppointmentStatus
                //inner join HospitalClinic,Patient
                var appointments = _unitOfWork.AppointmentRepository.
                    GetAll(x => x.PatientId == patientId
                    && x.AppointmentStatus == AppointmentStatus.Active,
                    includeEntities: "HospitalClinic,Patient");

                foreach (var item in appointments)
                {
                    //hastane
                    item.HospitalClinic.Hospital =
                        _unitOfWork.HospitalRepository.GetById(item.HospitalClinic.HospitalId);
                    //klinik
                    item.HospitalClinic.Clinic =
                        _unitOfWork.ClinicRepository.GetById(item.HospitalClinic.ClinicId);
                    //ilçe
                    item.HospitalClinic.Hospital.HospitalDistrict =
                        _unitOfWork.DistrictRepository.GetById(item.HospitalClinic.Hospital.DistrictId);
                    //il
                    item.HospitalClinic.Hospital.HospitalDistrict.City =
                        _unitOfWork.CityRepository.GetById(item.HospitalClinic.Hospital.HospitalDistrict.CityId);
                }

                var data = _mapper.Map<IQueryable<Appointment>, ICollection<AppointmentViewModel>>(appointments);

                return new SuccessDataResult<ICollection<AppointmentViewModel>>(data);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
