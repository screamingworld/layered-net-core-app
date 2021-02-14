using AutoMapper;
using Layered.Business.Contract.Abstractions;
using Layered.Business.Contract.Entities;
using Layered.DataLayer.Contract.Abstractions;
using Layered.DataLayer.Contract.Table;
using System.Threading;
using System.Threading.Tasks;

namespace Layered.Business.Services
{
    public class ItemDataService : IItemDataService
    {
        private readonly IRepository<Item> _repository;
        private readonly IMapper _mapper;
        public int Instance;
        public static int InstanceCount;

        public ItemDataService(
            IRepository<Item> repository,
            IMapper mapper)
        {
            InstanceCount++;
            Instance = InstanceCount;
            _repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        public async Task<ItemEntity> GetItem(string id, CancellationToken cancellationToken)
        {
            var row = await _repository.Get(id, cancellationToken);
            return _mapper.Map<ItemEntity>(row);
        }

        public async Task AddItem(ItemEntity entity, CancellationToken cancellationToken)
        {
            await _repository.Add(_mapper.Map<Item>(entity), cancellationToken);
        }
    }
}
