using AutoMapper;
using MHRS_ApplicationBusinessLayer.Abstracts;
using MHRS_ApplicationDataAccessLayer.Abstracts;
using MHRS_ApplicationEntityLayer.Models;
using MHRS_ApplicationEntityLayer.ResultModels;
using MHRS_ApplicationEntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationBusinessLayer.Concretes
{

    public class AppointmentHourManager : IAppointmentHourService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentHourManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IDataResult<ICollection<AppointmentHourViewModel>> GetAll(Expression<Func<AppointmentHourViewModel, bool>> filter)
        {
            try
            {
                var appointmentHourFilter = _mapper.Map<Expression<Func<AppointmentHourViewModel, bool>>, Expression<Func<AppointmentHour, bool>>>(filter);

                var appointmenHours = _unitOfWork.AppointmentHourRepository.GetAll(appointmentHourFilter);

                var data = _mapper.Map<IQueryable<AppointmentHour>, ICollection<AppointmentHourViewModel>>(appointmenHours);

                //Mesaj vermedik :D sadece datayı gönderdik.
                return new SuccessDataResult<ICollection<AppointmentHourViewModel>>(data);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }

}
