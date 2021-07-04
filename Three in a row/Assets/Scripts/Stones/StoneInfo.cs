using UnityEngine;

namespace ThreeInARow.Stones
{
    [CreateAssetMenu(menuName = "ThreeInARow/StoneInfo")]
    public class StoneInfo : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] int _id;

        public Sprite Sprite => _sprite;
        public int ID => _id;
    }
}