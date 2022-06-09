using MHRS_ApplicationEntityLayer.ResultModels;
using MHRS_ApplicationEntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationBusinessLayer.Abstracts
{
    public interface IDistrictService
    {
        //Bu servise silme güncelleme ekle vb. metot imzaları yazılabilir
        //Ancak şuanda bizim kısıtlı zamanımız old. için sadece ihtiyacımız olan metotları imzalayacağız
        IDataResult<ICollection<DistrictViewModel>> GetAllDistricts(Expression<Func<DistrictViewModel, bool>> filter);
        /// <summary>
        /// Bu metot cityidye göre ilçeleri getirir
        /// </summary>
        /// <param name="cityId">byte tipinde veri alır</param>
        /// <returns></returns>
        IDataResult<ICollection<DistrictViewModel>> GetDistrictsOfCity(byte cityId);

        IResult Add(DistrictViewModel district);


    }
}
