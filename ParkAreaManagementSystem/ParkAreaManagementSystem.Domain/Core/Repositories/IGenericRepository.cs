using System.Linq.Expressions;

namespace ParkAreaManagementSystem.Domain.Core.Repositories;

public interface IGenericRepository<TEntity> : IRepository<TEntity> where TEntity : IAggregateRoot
{
    Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
}
