using ClosedXML.Excel;
using MHRS_ApplicationBusinessLayer.Abstracts;
using MHRS_ApplicationEntityLayer.Enums;
using MHRS_ApplicationEntityLayer.IdentityModels;
using MHRS_ApplicationEntityLayer.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MHRS303UI.CreateDefaultData
{
    public static class CreateData
    {
        public static void Create(RoleManager<AppRole> roleManager,
            IWebHostEnvironment environment,
            ICityService cityManager, IDistrictService districtManager,
            IClinicService clinicManager)
        {
            CheckAndCreateRoles(roleManager);
            //illeri oluştur
            CreateCitiesByExcelFile(environment, cityManager);
            //ilçeleri oluştur
            CreateDistrictsByExcelFile(environment, districtManager);
            //klinikleri oluştur
            CreateClinicsByExcelFile(environment, clinicManager);
        }

        private static void CreateClinicsByExcelFile(IWebHostEnvironment environment, IClinicService clinicManager)
        {
            try
            {
                var clinicList = clinicManager.GetAllClinics(null).Data;
                string folderPath = Path.Combine(environment.WebRootPath, "Excels");
                string fileName = Path.GetFileName("Clinics.xlsx");
                string filePath = Path.Combine(folderPath, fileName);
                using (var excelBook = new XLWorkbook(filePath))
                {
                    var rows = excelBook.Worksheet(1).RowsUsed();
                    foreach (var item in rows)
                    {
                        if (item.RowNumber() > 1 && item.RowNumber() <= rows.Count())
                        {
                            var cell = item.Cell(1).Value.ToString(); //KBB
                            ClinicViewModel c = new ClinicViewModel()
                            {
                                ClinicName = cell,
                                CreatedDate = DateTime.Now
                            };
                            if (clinicList.Count(x => x.ClinicName.ToLower()
                            == cell.ToLower()) == 0)
                            {
                                clinicManager.Add(c);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //ex loglanabilir

            }
        }

        private static void CreateDistrictsByExcelFile(IWebHostEnvironment environment, IDistrictService districtManager)
        {
            try
            {
                var districts = districtManager.GetAllDistricts(null).Data;
                string folderPath = Path.Combine(environment.WebRootPath, "Excels");
                string fileName = Path.GetFileName("Districts.xlsx");
                string filePath = Path.Combine(folderPath, fileName);
                using (var excelBook = new XLWorkbook(filePath))
                {
                    var rows = excelBook.Worksheet(1).RowsUsed();
                    foreach (var item in rows)
                    {
                        if (item.RowNumber() > 1 && item.RowNumber() <= rows.Count())
                        {
                            var districtName = item.Cell(1).Value.ToString();
                            byte cityId = Convert.ToByte(item.Cell(2).Value.ToString());
                            if (districts.Count(x => x.DistrictName.ToLower()
                            == districtName.ToLower()) == 0)
                            {
                                DistrictViewModel d = new DistrictViewModel()
                                {
                                    DistrictName = districtName,
                                    CityId = cityId,
                                    CreatedDate = DateTime.Now
                                };
                                districtManager.Add(d);
                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                //ex loglanabilir

            }
        }

        private static void CreateCitiesByExcelFile(IWebHostEnvironment environment, ICityService cityManager)
        {
            try
            {
                var cityList = cityManager.GetAllCities(null).Data;
                // excelin olduğu yolu alalım
                string folderPath = Path.Combine(environment.WebRootPath, "Excels");
                string fileName = Path.GetFileName("Cities.xlsx");
                string filePath = Path.Combine(folderPath, fileName);
                using (var excelBook = new XLWorkbook(filePath))
                {
                    var rows = excelBook.Worksheet(1).RowsUsed();
                    foreach (var item in rows)
                    {
                        if (item.RowNumber() > 1 && item.RowNumber() <= rows.Count())
                        //81 kere dönecek
                        {
                            var cell = item.Cell(1).Value; //istanbul
                            var plateCode = item.Cell(2).Value; //34
                            CityViewModel c = new CityViewModel()
                            {
                                CityName = cell.ToString(),
                                PlateCode = Convert.ToByte(plateCode),
                                CreatedDate = DateTime.Now
                            };
                            //Eğer c diye isimlendirdiğimiz city tabloda yoksa eklesin
                            if (cityList.Count(x =>
                            x.CityName.ToLower() ==
                            cell.ToString().
                            ToLower()) == 0) //Eğer istanbuldan yoksa
                            {
                                cityManager.Add(c); //istanbulu ekle
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //ex loglanabilir
            }
        }

        private static void CheckAndCreateRoles(RoleManager<AppRole> roleManager)
        {
            try
            {
                //Enumdaki rolleri alsın dbye eklesin
                var allRoles = Enum.GetNames(typeof(MHRSRoles));
                foreach (var item in allRoles)
                {
                    //db'de rolden yoksa ekle!
                    //async bir metodu sonuna result yazarak senktron hale getirebilirsiniz
                    if (!roleManager.RoleExistsAsync(item).Result)
                    {
                        var role = new AppRole()
                        {
                            Name = item,
                            Description = $"Sistem tarafında {item} rolü oluşturuldu!"
                        };
                        var result = roleManager.CreateAsync(role).Result;
                    }
                }

            }
            catch (Exception ex)
            {
                //loglanabilir
                //sistem yöneticisine ACİL başlıklı email gönderilebilir

            }
        }


    }
}

