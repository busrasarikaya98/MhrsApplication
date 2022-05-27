﻿using MHRS_ApplicationDataAccessLayer.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationDataAccessLayer.Concretes
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly MyContext _myContext;

        public UnitOfWork(MyContext myContext)
        {
            _myContext = myContext;
            CityRepository = new CityRepository(_myContext);
            DistrictRepository = new DistrictRepository(_myContext);
            ClinicRepository = new ClinicRepository(_myContext);
            HospitalClinicRepository = new HospitalClinicRepository(_myContext);
            HospitalRepository = new HospitalRepository(_myContext);
            AppointmentRepository = new AppointmentRepository(_myContext);
            AppointmentHourRepository = new AppointmentHourRepository(_myContext);
        }

        public ICityRepository CityRepository {get; private set;}

        public IDistrictRepository DistrictRepository{get; private set;}

        public IClinicRepository ClinicRepository {get; private set;}

        public IHospitalRepository HospitalRepository {get; private set;}

        public IHospitalClinicRepository HospitalClinicRepository {get; private set;}

        public IAppointmentHourRepository AppointmentHourRepository {get; private set;}

        public IAppointmentRepository AppointmentRepository {get; private set;}

        public void Dispose()
        {
            _myContext.Dispose();
        }
    }
}
