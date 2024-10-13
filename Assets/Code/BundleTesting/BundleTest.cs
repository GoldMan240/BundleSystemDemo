using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.BundleTesting
{
    public class BundleTest : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private ItemBundleView _viewPrefab;
        [SerializeField] private Button _assembleBundleButton;
        
        [SerializeField] private TMP_InputField _titleInput;
        [SerializeField] private TMP_InputField _descriptionInput;
        [SerializeField] private BundleTestItemsContainer _itemsContainer;
        [SerializeField] private BundleTestImage _bundleImage;
        [SerializeField] private TMP_InputField _priceInput;
        [SerializeField] private TMP_InputField _discountInput;

        private void Awake()
        {
            _assembleBundleButton.onClick.AddListener(AssembleBundle);
        }

        private void OnDestroy()
        {
            _assembleBundleButton.onClick.RemoveListener(AssembleBundle);
        }

        private void AssembleBundle()
        {
            ItemBundleView view = Instantiate(_viewPrefab, _canvas.transform);
            ItemBundleModel model = new ItemBundleModel(view);
            ItemBundleController controller = new ItemBundleController(view, model);

            float discount = Convert.ToSingle(_discountInput.text) / 100;
            controller.ShowBundle(
                _titleInput.text,
                _descriptionInput.text,
                _itemsContainer.GetChosenItems().ToList(),
                _bundleImage.GetChosenSprite(),
                Convert.ToSingle(_priceInput.text),
                discount,
                OnPurchase);
        }

        private void OnPurchase()
        {
            Debug.Log("Purchased");
        }
    }
}