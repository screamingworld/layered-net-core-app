using System;
using System.Collections.Generic;

namespace Layered.DataLayer.Contract.Table
{
    public class Item : ITable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public List<Item> Children { get; private set; } = new List<Item>();
    }
}
