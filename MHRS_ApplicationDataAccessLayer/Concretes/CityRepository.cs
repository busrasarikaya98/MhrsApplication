using MHRS_ApplicationDataAccessLayer.Abstracts;
using MHRS_ApplicationEntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationDataAccessLayer.Concretes
{
    public class CityRepository : BaseRepository<City, byte>, ICityRepository
    {
        //base ctor ile kalkarken bunun da ctor ile ayaga kalkması gerekir o yuzden ctor olusturmak zorundayız, hangi parametre ile kalktıysa bu da o sekilde kalkacak
        public CityRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
