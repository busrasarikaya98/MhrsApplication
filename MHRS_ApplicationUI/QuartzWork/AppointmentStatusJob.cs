using MHRS_ApplicationBusinessLayer.Abstracts;
using MHRS_ApplicationEntityLayer.Enums;
using MHRS_ApplicationEntityLayer.Models;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHRS_ApplicationUI.QuartzWork
{
    public class AppointmentStatusJob : IJob
    {
        private readonly IAppointmentService _appointmentManager;
        private readonly IDenemeService _denemeManager;

        public AppointmentStatusJob(IAppointmentService appointmentManager, IDenemeService denemeManager)
        {
            _appointmentManager = appointmentManager;
            _denemeManager = denemeManager;
        }

        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                var appointments = _appointmentManager.GetAll(x => x.AppointmentStatus == MHRS_ApplicationEntityLayer.Enums.AppointmentStatus.Active).Data;
                foreach (var item in appointments)
                {
                    int itemHour = Convert.ToInt32(item.AppointmentHour.Substring(0, 2)); //9 veriyor
                    int itemMinute = Convert.ToInt32(item.AppointmentHour.Substring(3, 2)); //30 veriyor
                    if (item.AppointmentDate<DateTime.Now
                        ||
                        (item.AppointmentDate.ToShortDateString()
                        ==DateTime.Now.ToShortDateString()
                        &&
                        (
                        itemHour<DateTime.Now.Hour //bugün geçmiş saati
                        ||
                        (
                        itemHour==DateTime.Now.Hour&&itemMinute<DateTime.Now.Minute //bugün aynı saatin geçmiş dakikası
                        ))))
                    {
                        item.AppointmentStatus =AppointmentStatus.Past;
                        _appointmentManager.Update(item);
                    }
                }
                Deneme mesaj = new Deneme()
                {
                    CreatedDate = DateTime.Now,
                    Mesaj = "AppointmentStatusJob Çalıştı!"
                };
                _denemeManager.Add(mesaj);
                return Task.CompletedTask;
            }
            catch (Exception)
            {
                return Task.CompletedTask;
            }
        }
    }
}
