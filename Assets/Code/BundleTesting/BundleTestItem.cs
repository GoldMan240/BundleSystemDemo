using System;
using Code.ItemChoosing;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Code.BundleTesting
{
    public class BundleTestItem : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Button _button;
        [SerializeField] private TMP_InputField _amountInput;
        [FormerlySerializedAs("_itemModels")] [SerializeField] private ItemModelsConfig _itemModelsConfig;
        [FormerlySerializedAs("_itemIconsById")] [SerializeField] private ItemIconsByIdConfig _itemIconsByIdConfig;
        [SerializeField] private ChooseItemWindow _chooseItemWindowPrefab;
        [SerializeField] private Transform _windowContainer;
        
        private ItemModel _itemModel;

        public event Action OnChooseItem;

        private void Awake()
        {
            _button.onClick.AddListener(OpenChooseItemWindow);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OpenChooseItemWindow);
        }

        public ItemStackModel GetItemStackModel()
        {
            int amount = ConvertService.ToInt(_amountInput.text);
            return new ItemStackModel(_itemModel, amount);
        }

        private void OpenChooseItemWindow()
        {
            ChooseItemWindow chooseItemWindow = Instantiate(_chooseItemWindowPrefab, _windowContainer);
            chooseItemWindow.Display(_itemModelsConfig.GetItems(), _itemIconsByIdConfig, OnChoose);
        }

        private void OnChoose(ItemId id) 
        {
            _itemModel = _itemModelsConfig.GetItemById(id);
            _icon.sprite = _itemIconsByIdConfig.GetIconById(id);
            
            _button.gameObject.SetActive(false);
            
            OnChooseItem?.Invoke();
        }
    }
}