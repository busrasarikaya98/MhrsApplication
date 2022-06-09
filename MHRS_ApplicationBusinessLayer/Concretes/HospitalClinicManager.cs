using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

using System.Linq.Expressions;
using MHRS_ApplicationBusinessLayer.Abstracts;
using MHRS_ApplicationDataAccessLayer.Abstracts;
using MHRS_ApplicationEntityLayer.ViewModels;
using MHRS_ApplicationEntityLayer.ResultModels;
using MHRS_ApplicationEntityLayer.Models;

namespace MHRS303BusinessLayer.Concretes
{
    public class HospitalClinicManager : IHospitalClinicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public HospitalClinicManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IDataResult<ICollection<HospitalClinicViewModel>> GetAll(Expression<Func<HospitalClinicViewModel, bool>> filter)
        {
            try
            {

                var hospitalClinicFilter = _mapper.Map<Expression<Func<HospitalClinicViewModel, bool>>, Expression<Func<HospitalClinic, bool>>>(filter);

                var hospitalClinics = _unitOfWork.HospitalClinicRepository.GetAll(hospitalClinicFilter, 
                    includeEntities: "Clinic,Hospital,Doctor");

                var data = _mapper.Map<IQueryable<HospitalClinic>, ICollection<HospitalClinicViewModel>>(hospitalClinics);
                //Mesaj vermedik :D sadece datayı gönderdik.
                return new SuccessDataResult<ICollection<HospitalClinicViewModel>>(data);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}