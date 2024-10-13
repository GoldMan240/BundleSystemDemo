using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Code.ItemChoosing
{
    public class ChooseItemView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private Image _icon;
        [SerializeField] private Button _button;
        
        private ItemId _itemId;
        private Action<ItemId> _onChoose;

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnChoose);
        }

        public void Display(ItemModel itemModel, Sprite icon, Action<ItemId> onChoose)
        {
            _name.text = itemModel.Name;
            _icon.sprite = icon;
            
            _itemId = itemModel.Id;
            _onChoose = onChoose;
            
            _button.onClick.AddListener(OnChoose);
        }

        private void OnChoose() => 
            _onChoose?.Invoke(_itemId);
    }
}