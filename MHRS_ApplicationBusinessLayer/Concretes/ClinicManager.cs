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
    public class ClinicManager : IClinicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClinicManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IDataResult<ICollection<ClinicViewModel>> GetAllClinics(Expression<Func<ClinicViewModel, bool>> filter)
        {
            try
            {
                var clinicFilter = _mapper.Map<Expression<Func<ClinicViewModel, bool>>, Expression<Func<Clinic, bool>>>(filter);

                var clinics = _unitOfWork.ClinicRepository.GetAll(clinicFilter);

                var data = _mapper.Map<IQueryable<Clinic>, ICollection<ClinicViewModel>>(clinics);

                //Mesaj vermedik :D sadece datayı gönderdik.
                return new SuccessDataResult<ICollection<ClinicViewModel>>(data);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
