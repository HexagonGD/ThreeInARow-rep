using UnityEngine;

namespace ThreeInARow.Stones
{
    [CreateAssetMenu(menuName = "ThreeInARow/StoneConfig")]
    public class StoneConfig : ScriptableObject
    {
        [SerializeField] private StoneInfo[] _infos;

        public StoneInfo Get(int index)
        {
            return _infos[index];
        }

        public StoneInfo GetRandom()
        {
            var index = Random.Range(0, _infos.Length);
            return Get(index);
        }
    }
}