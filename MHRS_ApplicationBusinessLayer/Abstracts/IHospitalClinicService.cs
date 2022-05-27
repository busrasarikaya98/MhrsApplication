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
    public interface IHospitalClinicService
    {
        IDataResult<ICollection<HospitalClinicViewModel>> GetAll(Expression<Func<HospitalClinicViewModel, bool>> filter);
    }
}
