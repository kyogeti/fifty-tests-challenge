using System.Linq.Expressions;
using TestsChallenge.Shared.Abstractions;

namespace TestsChallenge.Shared.Repository;

public interface IBaseRepository<T> where T : IBaseModel
{
    Task<bool> Exists(Guid id);
    Task Add(T entity);
    Task Remove(T entity);
    Task Update(T entity);
    Task<T> GetOne(Guid id);
    Task<IEnumerable<T>> GetMany(Expression<Func<IBaseModel>>? condition);
    Task Deactivate(Guid id);
    Task Activate(Guid id);
}