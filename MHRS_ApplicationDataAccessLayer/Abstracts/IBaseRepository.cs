using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationDataAccessLayer.Abstracts
{
    public interface IBaseRepository<T,Id> where T:class,new()
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);

        //IDSI VERİLEN DATAYI GETİR
        T GetById(Id id);

        //ÖZELLİĞE GÖRE GETİR
        T GetFirstOrDefault(Expression<Func<T,bool>>filter,string includeEntities=null);
        //cityleri cekerken bunu cagırınca herhangi bir koşulla getirebilecegiz 
        //includeent iliskili oldugu tablodaki bilgileri getirecek

        //HEPSİNİ GETİR
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter, string includeEntities = null);

    }
}
