using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
    public class ItemStackView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _amount;
        
        public void DisplayItem(Sprite icon, int amount)
        {
            _icon.sprite = icon;
            _amount.text = amount.ToString();
        }
    }
}