﻿using Layered.DataLayer.Contract.Abstractions;
using Layered.DataLayer.Contract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Layered.DataLayer.Repositories
{
    // Fake repository which has no connection to persisting the data.
    // It is only a runtime repository.
    public class ItemRepository : IRepository<ItemEntity>
    {
        private List<ItemEntity> _store;
        
        public ItemRepository() 
        {
            // Adding runtime data for fake repo...
            _store = new List<ItemEntity> 
            {
                new ItemEntity
                {
                    Id = "1",
                    Name = "First",
                    Description = "This is the first item.",
                    CreationDate = new DateTimeOffset(new DateTime(2020, 1, 1)),
                    Position = 1,
                },
                new ItemEntity
                {
                    Id = "2",
                    Name = "Second",
                    Description = "This is the second item.",
                    CreationDate = new DateTimeOffset(new DateTime(2020, 1, 2)),
                    Position = 2,
                },
                new ItemEntity
                {
                    Id = "3",
                    Name = "Third",
                    Description = "This is the third item.",
                    CreationDate = new DateTimeOffset(new DateTime(2020, 1, 3)),
                    Position = 3,
                },
            };
        }


        public Task Add(ItemEntity item, CancellationToken cancellationToken)
        {
            if (_store.SingleOrDefault(x => x.Id == item.Id) != null)
                throw new InvalidOperationException($"The item with id: '{item.Id}' could not be added because it already exists.");
            
            _store.Add(item);

            return Task.CompletedTask;
        }

        public Task<ItemEntity> Get(string id, CancellationToken cancellationToken) 
            => Task.FromResult(_store.SingleOrDefault(x => x.Id == id));
    }
}
