using System;
using UnityEngine;

namespace Code.BundleTesting
{
    public class BundleTestItemsContainer : MonoBehaviour
    {
        [SerializeField] private BundleTestItem[] _items;

        private int _nextItemIndex;
        private int _chosenItemsCount;

        private void Awake()
        {
            foreach (BundleTestItem item in _items)
            {
                item.OnChooseItem += OnChoose;
                item.gameObject.SetActive(false);
            }
            
            UpdateItems();
        }

        private void OnDestroy()
        {
            foreach (BundleTestItem item in _items)
            {
                item.OnChooseItem -= OnChoose;
            }
        }

        public ItemStackModel[] GetChosenItems()
        {
            ItemStackModel[] chosenItems = new ItemStackModel[_chosenItemsCount];

            for (int i = 0; i < _chosenItemsCount; i++)
            {
                chosenItems[i] = _items[i].GetItemStackModel();
            }

            return chosenItems;
        }

        private void OnChoose()
        {
            _nextItemIndex++;
            _chosenItemsCount++;

            UpdateItems();
        }

        private void UpdateItems()
        {
            if (_chosenItemsCount >= _items.Length) return;

            _items[_nextItemIndex].gameObject.SetActive(true);
        }
    }
}