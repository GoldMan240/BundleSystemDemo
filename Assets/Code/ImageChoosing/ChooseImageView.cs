using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.ImageChoosing
{
    public class ChooseImageView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Button _button;
        
        private Action<Sprite> _onChoose;

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnChoose);
        }

        public void Display(Sprite icon, Action<Sprite> onChoose)
        {
            _icon.sprite = icon;
            
            _onChoose = onChoose;
            
            _button.onClick.AddListener(OnChoose);
        }

        private void OnChoose() => 
            _onChoose?.Invoke(_icon.sprite);
    }
}