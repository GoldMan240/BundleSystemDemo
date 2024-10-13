using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class ItemBundleController
    {
        private readonly ItemBundleView _view;
        private readonly ItemBundleModel _model;
        
        public ItemBundleController(ItemBundleView view, ItemBundleModel model)
        {
            _view = view;
            _model = model;
        }
        
        public void ShowBundle(string title, string description, List<ItemStackModel> items, Sprite bundleImage,
            float price, float discount, Action onPurchase)
        {
            _model.Initialize(title, description, items, bundleImage, price, discount, onPurchase);
        }
    }
}