using UnityEngine;

namespace Code
{
    [CreateAssetMenu(menuName = "Create ItemModels config", fileName = "ItemModels")]
    public class ItemModelsConfig : ScriptableObject
    {
        [SerializeField] private ItemModel[] _items;

        public ItemModel GetItemById(ItemId id)
        {
            foreach (ItemModel item in _items)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            Debug.LogError($"Item with id {id} not found!");
            return null;
        }
        
        public ItemModel[] GetItems() => 
            _items;
    }
}