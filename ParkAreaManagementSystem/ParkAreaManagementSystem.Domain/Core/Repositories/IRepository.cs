namespace ParkAreaManagementSystem.Domain.Core.Repositories;

public interface IRepository<TEntity> where TEntity : IAggregateRoot
{
    Task<TEntity> GetByIdAsync(int id);
    Task<IReadOnlyList<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}