using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.ItemChoosing
{
    public class ChooseItemWindow : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Transform _itemsContainer;
        [SerializeField] private ChooseItemView _chooseItemViewPrefab;
        
        private Action<ItemId> _onChoose;

        private void Awake()
        {
            _closeButton.onClick.AddListener(Close);
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveListener(Close);
        }

        public void Display(ItemModel[] itemModels, ItemIconsByIdConfig itemIconsByIdConfig, Action<ItemId> onChoose)
        {
            _onChoose = onChoose;
            
            foreach (ItemModel itemModel in itemModels)
            {
                ChooseItemView chooseItemView = Instantiate(_chooseItemViewPrefab, _itemsContainer);
                chooseItemView.Display(itemModel, itemIconsByIdConfig.GetIconById(itemModel.Id), OnChoose);
            }
        }

        private void OnChoose(ItemId id)
        {
            _onChoose?.Invoke(id);
            Close();
        }

        private void Close() => 
            Destroy(gameObject);
    }
}