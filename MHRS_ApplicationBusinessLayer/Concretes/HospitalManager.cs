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
    public class HospitalManager : IHospitalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public HospitalManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IDataResult<ICollection<HospitalViewModel>> GetAllHospitals(Expression<Func<HospitalViewModel, bool>> filter)
        {
            try
            {
                var hospitalFilter = _mapper.Map<Expression<Func<HospitalViewModel, bool>>, Expression<Func<Hospital, bool>>>(filter);

                var hospitals = _unitOfWork.HospitalRepository.GetAll(hospitalFilter);

                var data = _mapper.Map<IQueryable<Hospital>, ICollection<HospitalViewModel>>(hospitals);
                //Mesaj vermedik :D sadece datayı gönderdik.
                return new SuccessDataResult<ICollection<HospitalViewModel>>(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public IDataResult<ICollection<HospitalViewModel>> GetAllHospitalsByDistrictId(int districtId)
        //{
        //    try
        //    {
        //        if (districtId > 0)
        //        {
        //            //select * from Hospitals where DistrictID=754 //kadıköydeki hastaneler
        //            var hospitals = _unitOfWork.HospitalRepository.GetAll(x => x.DistrictId == districtId);
        //            var data = _mapper.Map<IQueryable<Hospital>, ICollection<HospitalViewModel>>(hospitals);
        //            // bu sefer canımız mesaj vermek istemedi :D 
        //            return new SuccessDataResult<ICollection<HospitalViewModel>>(data);
        //        }
        //        else
        //        {
        //            throw new Exception("HATA: districtId düzgün formatta değildir!");
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public IDataResult<ICollection<HospitalViewModel>> GetAllHospitalsByDistrictsId(int districtId)
        {
            try
            {
                if (districtId > 0)
                {
                    //select * from Hospitals where DistrictID=754 //kadıköydeki hastaneler
                    var hospitals = _unitOfWork.HospitalRepository.GetAll(x => x.DistrictId == districtId);
                    var data = _mapper.Map<IQueryable<Hospital>, ICollection<HospitalViewModel>>(hospitals);
                    // bu sefer canımız mesaj vermek istemedi :D 
                    return new SuccessDataResult<ICollection<HospitalViewModel>>(data);
                }
                else
                {
                    throw new Exception("HATA: districtId düzgün formatta değildir!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
