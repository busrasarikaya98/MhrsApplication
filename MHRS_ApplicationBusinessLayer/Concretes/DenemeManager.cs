using MHRS_ApplicationBusinessLayer.Abstracts;
using MHRS_ApplicationDataAccessLayer.Abstracts;
using MHRS_ApplicationEntityLayer.Models;
using MHRS_ApplicationEntityLayer.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationBusinessLayer.Concretes
{
    public class DenemeManager : IDenemeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DenemeManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IResult Add(Deneme deneme)
        {
            _unitOfWork.DenemeRepository.Add(deneme);
            return new SuccessResult();
        }
    }
}
