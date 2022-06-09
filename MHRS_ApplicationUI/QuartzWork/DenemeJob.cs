using MHRS_ApplicationBusinessLayer.Abstracts;
using MHRS_ApplicationEntityLayer.Models;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHRS_ApplicationUI.QuartzWork
{
    [DisallowConcurrentExecution]
    public class DenemeJob : IJob
    {
        private readonly IDenemeService _denemeManager;

        public DenemeJob(IDenemeService denemeManager)
        {
            _denemeManager = denemeManager;
        }

        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                Deneme denemem = new Deneme()
                {
                    CreatedDate = DateTime.Now,
                    Mesaj = $"Mesaj Eklendi..."
                };
                _denemeManager.Add(denemem);
                return Task.CompletedTask;
            }
            catch (Exception)
            {
                return Task.CompletedTask;
            }
        }
    }
}
