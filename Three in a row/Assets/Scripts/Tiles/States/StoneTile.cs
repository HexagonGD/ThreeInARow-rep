using ThreeInARow.Managers;

namespace ThreeInARow.Tiles.States
{
    public class StoneTile : ITileState
    {
        private Tile _tile;

        public StoneTile(Tile tile)
        {
            _tile = tile;
        }

        public bool IsMovable => false;

        public void Begin()
        {
            var sprite = General.Instance.GameResources.TileStoneSprite;
            _tile.SetTileSprite(sprite);
            _tile.ChangeStone(null, _tile.transform.position);
        }

        public void Blow() { }

        public void End() { }

        public int GetStoneID()
        {
            return -1;
        }

        public bool NeedStone() => false;
    }
}