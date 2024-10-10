using UnityEngine;

namespace Code
{
    [CreateAssetMenu(menuName = "Create ItemIconsById", fileName = "ItemIconsById")]
    public class ItemIconsById : ScriptableObject
    {
        [SerializeField] private ItemIconById[] _itemIcons;

        public Sprite GetIconById(ItemId id)
        {
            foreach (ItemIconById itemIcon in _itemIcons)
            {
                if (itemIcon.Id == id)
                {
                    return itemIcon.Icon;
                }
            }

            Debug.LogError($"Icon for item with id {id} not found!");
            return null;
        }
    }
}