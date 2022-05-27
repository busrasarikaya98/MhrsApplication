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
    public class CityManager : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CityManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IResult Add(CityViewModel city)
        {
            try
            {
                //parametre olarak gelen cityviewmodeli city e dönüştür
                City newCity = _mapper.Map<CityViewModel, City>(city);
                var insertResult = _unitOfWork.CityRepository.Add(newCity);
                return insertResult ?
                    new SuccessResult("İl Eklendi!") : new ErrorResult("İl Ekleme Başarısız!");
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IResult Delete(CityViewModel city)
        {
            try
            {
                //parametre olarak gelen cityviewmodeli city e dönüştür
                City deleteCity = _mapper.Map<CityViewModel, City>(city);
                var deleteResult = _unitOfWork.CityRepository.Delete(deleteCity);
                return deleteResult ?
                    new SuccessResult("İl Silindi!") : new ErrorResult($"{deleteCity.CityName} Adlı Şehir Silinemedi!");

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IDataResult<ICollection<CityViewModel>> GetAllCities(Expression<Func<CityViewModel, bool>> filter)
        {
            try
            {
                //data katmanı bana tüm illeri getir
                //select*from Cities inner join Districts
                var cityFilter = _mapper.Map<Expression<Func<CityViewModel, bool>>, Expression<Func<City, bool>>>
                    (filter);
                var cities = _unitOfWork.CityRepository.GetAll(cityFilter, includeEntities: "Districts");
                ICollection<CityViewModel> list =
                    _mapper.Map<IQueryable<City>, ICollection<CityViewModel>>(cities);
                //eğer mapper olmasaydı cityname=item.cityname ... seklindeki inner joinle ugrasırdık
                return new SuccessDataResult<ICollection<CityViewModel>>(list, $"{list.Count} adet il listelendi!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IDataResult<CityViewModel> GetById(byte id)
        {
            try
            {
                if (id>0)
                {
                    var city = _unitOfWork.CityRepository.GetById(id);
                    if (city==null)
                    {
                        throw new Exception("Hata: İl Bulunamadı!");
                    }
                    CityViewModel data = _mapper.Map<City, CityViewModel>(city);
                    return new SuccessDataResult<CityViewModel>(data,$"{id} ID'li şehire ait bilgiler gönderildi!");
                }
                else
                {
                    throw new Exception("Hata: Id parametresi düzgün verilmemiştir!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IDataResult<CityViewModel> GetFirstOrDefault(Expression<Func<CityViewModel, bool>> filter)
        {
            //TO DO burada neye göre firstordefault yapacak
            try
            {
                var cityFilter = _mapper.Map<Expression<Func<CityViewModel, bool>>, Expression<Func<City, bool>>>
                    (filter);
                var city = _unitOfWork.CityRepository.GetFirstOrDefault(cityFilter, "Districts");
                if (city==null)
                {
                    throw new Exception("Hata: İl Bulunamadı!");
                }
                CityViewModel data = _mapper.Map<City, CityViewModel>(city);
                return new SuccessDataResult<CityViewModel>(data, "İl Bulundu!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IResult Update(CityViewModel city)
        {
            try
            {
                //parametre olarak gelen cityviewmodeli city e dönüştür
                City updateCity = _mapper.Map<CityViewModel, City>(city);
                var updateResult = _unitOfWork.CityRepository.Update(updateCity);
                return updateResult ?
                    new SuccessResult("İl Güncellendi!") : new ErrorResult("İl Güncelleme Başarısız!");

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
