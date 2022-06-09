using MHRS_ApplicationBusinessLayer.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHRS_ApplicationUI.Controllers
{
    public class CityController : Controller
    {
        private readonly IDistrictService _districtManager;
        public CityController(IDistrictService districtManager)
        {
            _districtManager = districtManager;
        }
        public JsonResult GetCityDistricts(int id)
        {
            try
            {
                var data = _districtManager.GetDistrictsOfCity(Convert.ToByte(id)).Data;
                //return Json(new { isSuccess = true, data=data });
                return Json(new { isSuccess = true, data });
            }
            catch (Exception ex)
            {
                return Json(new { isSuccess = false });
            }
        }
    }
}
