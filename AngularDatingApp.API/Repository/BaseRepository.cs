using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AngularDatingApp.API.IRepository;
using Microsoft.EntityFrameworkCore;

namespace AngularDatingApp.API.Repository
{
    public class BaseRepository<TEntity, UID> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly IAppUnitOfWork _unitOfWork;
        public BaseRepository(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Add(TEntity entity)
        => await _unitOfWork.Context.Set<TEntity>().AddAsync(entity);

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
        => await _unitOfWork.Context.Set<TEntity>().Where(predicate).ToListAsync();

        public async Task<IEnumerable<TEntity>> Get()
        => await _unitOfWork.Context.Set<TEntity>().ToListAsync();

        public void UpdateAsync(TEntity entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Context.Set<TEntity>().Attach(entity);
        }

        public void Delete(TEntity entity)
        {
            TEntity existing = _unitOfWork.Context.Set<TEntity>().Find(entity);
            if (existing != null)
            {
                _unitOfWork.Context.Set<TEntity>().Remove(existing);
            }
        }
    }
}