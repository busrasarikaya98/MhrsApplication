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
    public interface ICityService
    {
        IResult Add(CityViewModel city); //business ve ui viewmodellerle konusur, data modellerle konusur
        IResult Update(CityViewModel city);
        IResult Delete(CityViewModel city);
        IDataResult<ICollection<CityViewModel>> GetAllCities(Expression<Func<CityViewModel, bool>> filter);
        IDataResult<CityViewModel> GetFirstOrDefault(Expression<Func<CityViewModel, bool>> filter);
        IDataResult<CityViewModel> GetById(byte id);


    }
}
