using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DesafioBackEnvelope.Domain.Interfaces;


namespace DesafioBackEnvelope.Infra.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _Db;
        public BaseRepository()
        {
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync() =>
            await _Db.Set<T>().AsNoTracking().ToListAsync();    

        public virtual async Task<T> GetByIdAsync(int id) => 
            await _Db.Set<T>().FindAsync(id);

        public virtual async Task<IEnumerable<T>> GetByParamAsync(Expression<Func<T, bool>> predicate) =>
            await _Db.Set<T>().Where(predicate).ToListAsync();
        
        public virtual async Task<T> InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            await _Db.Set<T>().AddAsync(entity);
            await _Db.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<IEnumerable<T>> InsertRangeAsync(IEnumerable<T> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await _Db.Set<T>().AddRangeAsync(entity);
            await _Db.SaveChangesAsync();

            return entity;
        }

        public virtual Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _Db.Set<T>().Update(entity);
            return _Db.SaveChangesAsync();
        }

        public virtual Task UpdateRangeAsync(IEnumerable<T> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _Db.Set<T>().UpdateRange(entity);
            return _Db.SaveChangesAsync();
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                _Db.Set<T>().Remove(entity);
                await _Db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public virtual async Task<bool> DeleteRangeAsync(IEnumerable<T> entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                _Db.Set<T>().RemoveRange(entity);
                await _Db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
