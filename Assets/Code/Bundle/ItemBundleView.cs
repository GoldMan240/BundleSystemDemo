using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Code
{
    public class ItemBundleView : MonoBehaviour
    {
        [Header("Main info")]
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private Transform _itemsContainer;
        [SerializeField] private List<ItemStackView> _itemViews;
        [SerializeField] private Image _bundleImage;
        [Header("Button")]
        [SerializeField] private Button _purchaseButton;
        [SerializeField] private TextMeshProUGUI _finalPrice;
        [SerializeField] private TextMeshProUGUI _defaultPrice;
        [SerializeField] private Transform _discountContainer;
        [SerializeField] private TextMeshProUGUI _discount;
        [FormerlySerializedAs("_itemIconsById")]
        [Header("Icons")]
        [SerializeField] private ItemIconsByIdConfig _itemIconsByIdConfig;

        private Action _onPurchase;

        private void OnDestroy()
        {
            _purchaseButton.onClick.RemoveListener(OnPurchase);
        }

        public void DisplayBundle(string title, string description, List<ItemStackModel> items, Sprite bundleImage,
            float price, float discount, float priceWithDiscount, Action onPurchase)
        {
            _title.text = title;
            _description.text = description;
            _bundleImage.sprite = bundleImage;
            
            DisplayItems(items);
            DisplayPrice(price, discount, priceWithDiscount);
            
            _onPurchase = onPurchase;
            _purchaseButton.onClick.AddListener(OnPurchase);
        }

        private void DisplayItems(List<ItemStackModel> items)
        {
            if (items.Count > _itemViews.Count)
            {
                Debug.LogError($"Not enough item views for items. Expected: {items.Count}, Actual: {_itemViews.Count}");
                return;
            }
            
            for (int i = 0; i < items.Count; i++)
            {
                ItemStackModel itemStack = items[i];
                ItemStackView itemStackView = _itemViews[i];
                
                itemStackView.DisplayItem(_itemIconsByIdConfig.GetIconById(itemStack.ItemModel.Id), itemStack.Amount);
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

        private void OnPurchase()
        {
            _onPurchase?.Invoke();
        }
    }
}