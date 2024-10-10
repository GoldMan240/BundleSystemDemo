using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class ItemBundleModel
    {
        private readonly ItemBundleView _view;
        
        private string _title;
        private string _description;
        private Sprite _bundleImage;
        private float _price;
        private float _discount;
        private List<ItemModel> _items;

        public ItemBundleModel(ItemBundleView view)
        {
            _view = view;
        }
        
        public void Initialize(string title, string description, Sprite bundleImage, float price, float discount, List<ItemModel> items)
        {
            _title = title;
            _description = description;
            _bundleImage = bundleImage;
            _price = price;
            _discount = discount;
            _items = items;
            
            _view.DisplayBundle(_title, _description, _bundleImage, _price, _discount, CalculatePriceWithDiscount(), _items);
        }

        private float CalculatePriceWithDiscount() => 
            _price * (1 - _discount);
    }
}
