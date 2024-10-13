using System;
using Code.ImageChoosing;
using UnityEngine;
using UnityEngine.UI;

namespace Code.BundleTesting
{
    public class BundleTestImage : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Button _button;
        [SerializeField] private BundleImagesConfig _bundleImages;
        [SerializeField] private ChooseImageWindow _chooseItemWindowPrefab;
        [SerializeField] private Transform _windowContainer;
        
        private Sprite _image;

        private void Awake()
        {
            _button.onClick.AddListener(OpenChooseItemWindow);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OpenChooseItemWindow);
        }

        public Sprite GetChosenSprite() =>
            _image;

        private void OpenChooseItemWindow()
        {
            ChooseImageWindow chooseItemWindow = Instantiate(_chooseItemWindowPrefab, _windowContainer);
            chooseItemWindow.Display(_bundleImages.Images, OnChoose);
        }

        private void OnChoose(Sprite image) 
        {
            _image = image;
            _icon.sprite = image;
            
            _button.gameObject.SetActive(false);
        }
    }
}