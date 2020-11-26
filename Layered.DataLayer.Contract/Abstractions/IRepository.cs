using Layered.DataLayer.Contract.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Layered.DataLayer.Contract.Abstractions
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task<ItemEntity> Get(string id, CancellationToken cancellationToken);
        Task Add(TEntity entity, CancellationToken cancellationToken);

        // Further methods for real world yes...
    }
}
