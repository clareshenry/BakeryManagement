using BakeryManagement.Domain.Interfaces;
using BakeryManagement.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BakeryManagement.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly AppDbContext _dbContext;

        protected BaseRepository(AppDbContext context)
        {
            _dbContext = context;
        }

        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().AddRange(entities);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public virtual IQueryable<TEntity> GetAllNoTracking()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public virtual async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
