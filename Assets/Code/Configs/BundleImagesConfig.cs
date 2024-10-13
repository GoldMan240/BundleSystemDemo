using UnityEngine;

namespace Code
{
    [CreateAssetMenu(menuName = "Create BundleImages config", fileName = "BundleImages")]
    public class BundleImagesConfig : ScriptableObject
    {
        [field: SerializeField] public Sprite[] Images { get; private set; }
    }
}