using AutoMapper;
using MHRS_ApplicationBusinessLayer.Abstracts;
using MHRS_ApplicationDataAccessLayer.Abstracts;
using MHRS_ApplicationEntityLayer.Enums;
using MHRS_ApplicationEntityLayer.IdentityModels;
using MHRS_ApplicationEntityLayer.Models;
using MHRS_ApplicationEntityLayer.ResultModels;
using MHRS_ApplicationEntityLayer.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationBusinessLayer.Concretes
{
    public class AppointmentManager : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public AppointmentManager(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public IDataResult<ICollection<AppointmentViewModel>> GetAll(Expression<Func<AppointmentViewModel, bool>> filter)
        {
            try
            {
                var appointmentFilter = _mapper.Map<Expression<Func<AppointmentViewModel, bool>>, Expression<Func<Appointment, bool>>>(filter);

                var appointment = _unitOfWork.AppointmentRepository.GetAll(appointmentFilter);

                var data = _mapper.Map<IQueryable<Appointment>, ICollection<AppointmentViewModel>>(appointment);

                //Mesaj vermedik :D sadece datayı gönderdik.
                return new SuccessDataResult<ICollection<AppointmentViewModel>>(data);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IDataResult<AppointmentViewModel> GetAppointmentByIDs(string patientId, int hospitalClinicId, DateTime appointmentDate, string appointmentHour)
        {
            try
            {
                var appointment = _unitOfWork.AppointmentRepository
                    .GetFirstOrDefault(x =>
                    x.PatientId == patientId
                    && x.HospitalClinicId == hospitalClinicId
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
                var data = _mapper.Map<IQueryable<Appointment>, ICollection<AppointmentViewModel>>(appointments);
                foreach (var item in data)
                {
                    //HospitalClinic
                    item.HospitalClinic =
                        _mapper.Map<HospitalClinic, HospitalClinicViewModel>(
                            _unitOfWork.HospitalClinicRepository.GetById(item.HospitalClinicId));
                    //hastane
                    item.Hospital =
                       _mapper.Map<Hospital, HospitalViewModel>(_unitOfWork.HospitalRepository.GetById(item.HospitalClinic.HospitalId));
                    //klinik
                    item.Clinic = _mapper.Map<Clinic, ClinicViewModel>(
                         _unitOfWork.ClinicRepository.GetById(item.HospitalClinic.ClinicId));
                    //ilçe
                    item.Hospital.HospitalDistrict =
                        _mapper.Map<District, DistrictViewModel>(
                        _unitOfWork.DistrictRepository.GetById(item.Hospital.DistrictId));
                    //il
                    item.Hospital.HospitalDistrict.City =
                         _mapper.Map<City, CityViewModel>(
                        _unitOfWork.CityRepository.GetById(Convert.ToByte(item.Hospital.HospitalDistrict.CityId)));

                    //doktor 
                    item.Doctor = _userManager.FindByIdAsync(item.HospitalClinic.DoctorId).Result;
                }
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
                var data = _mapper.Map<IQueryable<Appointment>, ICollection<AppointmentViewModel>>(appointments);
                foreach (var item in data)
                {
                    //HospitalClinic
                    item.HospitalClinic =
                        _mapper.Map<HospitalClinic, HospitalClinicViewModel>(
                            _unitOfWork.HospitalClinicRepository.GetById(item.HospitalClinicId));
                    //hastane
                    item.Hospital =
                       _mapper.Map<Hospital, HospitalViewModel>(_unitOfWork.HospitalRepository.GetById(item.HospitalClinic.HospitalId));
                    //klinik
                    item.Clinic = _mapper.Map<Clinic, ClinicViewModel>(
                         _unitOfWork.ClinicRepository.GetById(item.HospitalClinic.ClinicId));
                    //ilçe
                    item.Hospital.HospitalDistrict =
                        _mapper.Map<District, DistrictViewModel>(
                        _unitOfWork.DistrictRepository.GetById(item.Hospital.DistrictId));
                    //il
                    item.Hospital.HospitalDistrict.City =
                         _mapper.Map<City, CityViewModel>(
                        _unitOfWork.CityRepository.GetById(Convert.ToByte(item.Hospital.HospitalDistrict.CityId)));

                    //doktor 
                    item.Doctor = _userManager.FindByIdAsync(item.HospitalClinic.DoctorId).Result;
                }


                

                return new SuccessDataResult<ICollection<AppointmentViewModel>>(data);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public IResult Add(AppointmentViewModel appointment)
        {
            try
            {
                Appointment newappointment = _mapper.Map<AppointmentViewModel, Appointment>(appointment);

                var insertResult = _unitOfWork.AppointmentRepository.Add(newappointment);

                return insertResult ?
                    new SuccessResult("Randevu başarılı olarak eklendi!")
                    :
                    new ErrorResult("Randevu oluşturma işlemi BAŞARISIZ!");

            }
            catch (Exception)
            {

                throw;
            }

        }
        public IResult Update(AppointmentViewModel appointment)
        {
            try
            {
                //parametre olarak gelen cityviewmodeli city e dönüştür
                Appointment a = _mapper.Map<AppointmentViewModel, Appointment>(appointment);
                var updateResult = _unitOfWork.AppointmentRepository.Update(a);
                return updateResult ?
                    new SuccessResult($"Randevu Güncellendi!") : new ErrorResult($"Randevu Güncelleme Başarısız!");

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
