using Layered.DataLayer.Contract.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Layered.Business.Contract.Abstractions
{
    public interface IItemDataService
    {
        Task<ItemEntity> GetItem(string id, CancellationToken cancellationToken);
        Task AddItem(ItemEntity entity, CancellationToken cancellationToken);
    }
}
