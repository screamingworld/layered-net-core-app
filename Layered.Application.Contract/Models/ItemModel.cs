using System;
using System.Collections.Generic;

namespace Layered.Application.Contract.Models
{
    /// <summary>
    /// Simply a model which will be used to create and view an item.
    /// I have chosen this type cause of simplicity.
    /// In real live we mostly have some concreter view models and creation models.
    /// </summary>
    public class ItemModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public List<ItemModel> Children { get; private set; } = new List<ItemModel>();
    }
}
