using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.ImageChoosing
{
    public class ChooseImageWindow : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Transform _itemsContainer;
        [SerializeField] private ChooseImageView _chooseImageViewPrefab;
        
        private Action<Sprite> _onChoose;

        private void Awake()
        {
            _closeButton.onClick.AddListener(Close);
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveListener(Close);
        }

        public void Display(Sprite[] images, Action<Sprite> onChoose)
        {
            _onChoose = onChoose;
            
            foreach (Sprite image in images)
            {
                ChooseImageView chooseImageView = Instantiate(_chooseImageViewPrefab, _itemsContainer);
                chooseImageView.Display(image, OnChoose);
            }
        }

        private void OnChoose(Sprite image)
        {
            _onChoose?.Invoke(image);
            Close();
        }

        private void Close() => 
            Destroy(gameObject);
    }
}