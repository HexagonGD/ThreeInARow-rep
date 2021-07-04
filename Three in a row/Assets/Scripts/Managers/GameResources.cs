using ThreeInARow.Stones;
using ThreeInARow.Tiles;
using UnityEngine;

namespace ThreeInARow.Managers
{
    [CreateAssetMenu(menuName = "ThreeInARow/GameResources")]
    public class GameResources : ScriptableObject
    {
        [SerializeField] private Sprite _tileSimpleSprite;
        [SerializeField] private Sprite _tileFreezeSprite;
        [SerializeField] private Sprite _tileStoneSprite;
        [SerializeField] private Tile _tilePrefab;
        [SerializeField] private StoneConfig _stoneConfig;

        public Sprite TileSimpleSprite => _tileSimpleSprite;
        public Sprite TileFreezeSprite => _tileFreezeSprite;
        public Sprite TileStoneSprite => _tileStoneSprite;
        public Tile TilePrefab => _tilePrefab;
        public StoneConfig StoneConfig => _stoneConfig;
    }
}