using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class BundleTest : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private ItemBundleView _viewPrefab;
        [SerializeField] private Sprite _bundleImage;
        
        private void Start()
        {
            ItemBundleView view = Instantiate(_viewPrefab, _canvas.transform);
            ItemBundleModel model = new ItemBundleModel(view);
            ItemBundleController controller = new ItemBundleController(view, model);
            
            controller.ShowBundle("Bundle", "Bundle description", _bundleImage, 100f, 0.1f, new List<ItemModel>
            {
                new ItemModel(ItemId.WoodLog, "Wood Log", 10),
                new ItemModel(ItemId.Stone, "Stone", 5),
                new ItemModel(ItemId.WoodStick, "Wood Stick", 15),
            });
        }
    }
}