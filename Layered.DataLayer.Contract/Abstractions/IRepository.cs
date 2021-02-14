using Layered.DataLayer.Contract.Table;
using System.Threading;
using System.Threading.Tasks;

namespace Layered.DataLayer.Contract.Abstractions
{
    public interface IRepository<TTable> where TTable : ITable
    {
        Task<Item> Get(string id, CancellationToken cancellationToken);
        Task Add(TTable entity, CancellationToken cancellationToken);

        // Further methods for real world yes...
    }
}
