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
    public class DistrictManager : IDistrictService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DistrictManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IDataResult<ICollection<DistrictViewModel>> GetAllDistricts(Expression<Func<DistrictViewModel, bool>> filter)
        {
            try
            {
                var districtFilter = _mapper.Map<Expression<Func<DistrictViewModel, bool>>, Expression<Func<District, bool>>>(filter);
                var districts = _unitOfWork.DistrictRepository.GetAll(districtFilter);
                var data = _mapper.Map<IQueryable<District>, ICollection<DistrictViewModel>>(districts);
                //mesaj vermeden sadece data gönderme
                return new SuccessDataResult<ICollection<DistrictViewModel>>(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IDataResult<ICollection<DistrictViewModel>> GetDistrictsOfCity(byte cityId)
        {
            try
            {
                if (cityId > 0)
                {
                    //select * from Districts where CityId=34
                    var districts = _unitOfWork.DistrictRepository.GetAll(x => x.CityId == cityId);
                    var data = _mapper.Map<IQueryable<District>, ICollection<DistrictViewModel>>(districts);
                    // bu sefer canımız mesaj vermek istemedi :D 
                    return new SuccessDataResult<ICollection<DistrictViewModel>>(data);
                }
                else
                {
                    throw new Exception("HATA: cityId düzgün formatta değildir!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
