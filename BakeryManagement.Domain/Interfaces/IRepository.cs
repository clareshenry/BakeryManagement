namespace BakeryManagement.Domain.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        void Add(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        IQueryable<TEntity> GetAll();

        Task<IEnumerable<TEntity>> GetAllAsync();

        IQueryable<TEntity> GetAllNoTracking();

        Task<TEntity?> GetByIdAsync(int id);

        void Update(TEntity entity);
    }
}
