using Layered.Application.Contract.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Layered.Application.Contract.Services
{
    public interface IItemService
    {
        Task<ItemModel> GetItem(string id, CancellationToken cancellationToken);
        Task PostItem(ItemModel itemModel, CancellationToken cancellationToken);
    }
}
