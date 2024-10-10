using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
    public class ItemBundleView : MonoBehaviour
    {
        [Header("Main info")]
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private Transform _itemsContainer;
        [SerializeField] private List<ItemView> _itemViews;
        [SerializeField] private Image _bundleImage;
        [Header("Button")]
        [SerializeField] private TextMeshProUGUI _finalPrice;
        [SerializeField] private TextMeshProUGUI _defaultPrice;
        [SerializeField] private Transform _discountContainer;
        [SerializeField] private TextMeshProUGUI _discount;
        [Header("Icons")]
        [SerializeField] private ItemIconsById _itemIconsById;
        
        public void DisplayBundle(string title, string description, Sprite bundleImage, float price, float discount, float priceWithDiscount, List<ItemModel> items)
        {
            _title.text = title;
            _description.text = description;
            _bundleImage.sprite = bundleImage;
            
            DisplayItems(items);
            DisplayPrice(price, discount, priceWithDiscount);
        }

        private void DisplayItems(List<ItemModel> items)
        {
            if (items.Count > _itemViews.Count)
            {
                Debug.LogError($"Not enough item views for items. Expected: {items.Count}, Actual: {_itemViews.Count}");
                return;
            }
            
            for (int i = 0; i < items.Count; i++)
            {
                ItemModel item = items[i];
                ItemView itemView = _itemViews[i];
                
                itemView.DisplayItem(_itemIconsById.GetIconById(item.Id), item.Amount);
            }
            
            for (int i = items.Count; i < _itemViews.Count; i++) 
                _itemViews[i].gameObject.SetActive(false);
        }

        private void DisplayPrice(float price, float discount, float priceWithDiscount)
        {
            _defaultPrice.text = price.ToString("$#.#");
            _discount.text = discount.ToString("-#%");
            _finalPrice.text = priceWithDiscount.ToString("$#.#");
            
            
            bool isDiscount = discount > 0;
            _defaultPrice.gameObject.SetActive(isDiscount);
            _discountContainer.gameObject.SetActive(isDiscount);
        }
    }
}