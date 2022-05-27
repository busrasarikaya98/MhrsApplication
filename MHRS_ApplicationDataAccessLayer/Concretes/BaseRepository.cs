using MHRS_ApplicationDataAccessLayer.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationDataAccessLayer.Concretes
{
    public class BaseRepository<T, Id> : IBaseRepository<T, Id> where T:class,new()
    {
        protected readonly MyContext _myContext; //readonly dısardan set engelleme, sadece ctordan setlenir
        public BaseRepository(MyContext myContext)
        {
            _myContext = myContext;
        }
        public bool Add(T entity)
        {
            try
            {
                _myContext.Set<T>().Add(entity);
                //ternary if
                return _myContext.SaveChanges() > 0 ? true : false; //bool bu sekilde voidden farkı > ozelligi
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Delete(T entity)
        {
            try
            {
                _myContext.Set<T>().Remove(entity);
                //ternary if
                return _myContext.SaveChanges() > 0 ? true : false; //bool bu sekilde voidden farkı > ozelligi
            }
            catch (Exception)
            {
                throw;
            }
        }
        public T GetById(Id id)
        {
            try
            {
                return _myContext.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Update(T entity)
        {
            try
            {
                _myContext.Set<T>().Update(entity);
                //ternary if
                return _myContext.SaveChanges() > 0 ? true : false; 
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter, string includeEntities = null)
        {
            try
            {
                IQueryable<T> query = _myContext.Set<T>();
                if (filter!=null) //koşul varsa
                {
                    query=query.Where(filter); //select*from tabloadı sorgusuna where keywordu eklesin. boylece kosula uygun veriler gelecektir
                }
                if (includeEntities != null) //null degilse
                {
                    var includes = includeEntities.Split(',');
                    //kaç tane ilişkili olduğu tablo varsa onların isimlerini virgül koyarak bana includeentities gönderecek.
                    //gelen bu bilgiyi virgülden itibaren ayırıp ve tabloya inner join edeceğiz
                    foreach (var item in includes)
                    {
                        query = query.Include(item); //inner join
                    }
                }
                return query;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string includeEntities = null)
        {
            try
            {
                IQueryable<T> query = _myContext.Set<T>();
                if (filter != null)
                {
                    query=query.Where(filter);
                }
                if (includeEntities != null)
                {
                    var includes = includeEntities.Split(',');
                    foreach (var item in includes)
                    {
                        query = query.Include(item); //inner join
                    }
                }
                return query.FirstOrDefault(); //getalldan tek farkı
            }
            catch (Exception)
            {
                throw;
            }
        }       
    }
}
