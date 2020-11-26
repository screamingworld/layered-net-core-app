using System;
using System.Collections.Generic;

namespace Layered.DataLayer.Contract.Entities
{
    public class ItemEntity : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public List<ItemEntity> Children { get; private set; } = new List<ItemEntity>();
    }
}
