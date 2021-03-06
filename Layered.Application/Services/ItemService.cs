﻿using AutoMapper;
using FluentValidation;
using Layered.Application.Contract.Models;
using Layered.Application.Contract.Services;
using Layered.Business.Contract.Abstractions;
using Layered.Business.Contract.Entities;
using Layered.Common.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Layered.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemDataService _itemDataService;
        private readonly IMapper _mapper;
        private readonly IValidator<ItemModel> _validator;
        public int Instance;
        public static int InstanceCount;

        public ItemService(
            IItemDataService itemDataService,
            IMapper mapper,
            IValidator<ItemModel> validator)
        {
            InstanceCount++;
            _itemDataService = itemDataService ?? throw new System.ArgumentNullException(nameof(itemDataService));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
            _validator = validator;
            Instance = InstanceCount;
        }

        public async Task<ItemModel> GetItem(string id, CancellationToken cancellationToken)
        {
            var entity = await _itemDataService.GetItem(id, cancellationToken);
            var item = _mapper.Map<ItemModel>(entity);

            return item;
        }

        public async Task PostItem(ItemModel itemModel, CancellationToken cancellationToken)
        {
            _validator.ValidateCustom(itemModel);

            var entity = _mapper.Map<ItemEntity>(itemModel);

            await _itemDataService.AddItem(entity, cancellationToken);
        }
    }
}
