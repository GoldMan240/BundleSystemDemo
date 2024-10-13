using System;
using UnityEngine;

namespace Code
{
    [Serializable]
    public class ItemModel
    {
        [field: SerializeField] public ItemId Id { get; private set; }
        [field: SerializeField] public string Name { get; private set; }

        public ItemModel(ItemId id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}