using Layered.Application.Contract.Models;
using Layered.Application.Contract.Services;
using Layered.WebApi.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.AppLayerValidation.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemController : CustomController
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService ?? throw new System.ArgumentNullException(nameof(itemService));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(List<ItemModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get([FromRoute] string id, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(() => _itemService.GetItem(id, cancellationToken));
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] ItemModel item, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(() => _itemService.PostItem(item, cancellationToken));
        }
    }
}
