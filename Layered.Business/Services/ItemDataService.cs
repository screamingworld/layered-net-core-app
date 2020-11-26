using Layered.Business.Contract.Abstractions;
using Layered.DataLayer.Contract.Abstractions;
using Layered.DataLayer.Contract.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Layered.Business.Services
{
    public class ItemDataService : IItemDataService
    {
        private readonly IRepository<ItemEntity> _repository;

        public ItemDataService(IRepository<ItemEntity> repository)
        {
            _repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        public async Task<ItemEntity> GetItem(string id, CancellationToken cancellationToken)
        {
            return await _repository.Get(id, cancellationToken);
        }

        public async Task AddItem(ItemEntity entity, CancellationToken cancellationToken)
        {
            await _repository.Add(entity, cancellationToken);
        }
    }
}
