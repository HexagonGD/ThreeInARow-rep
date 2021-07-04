using ThreeInARow.Managers;

namespace ThreeInARow.Tiles.States
{
    public class SimpleTile : ITileState
    {
        private Tile _tile;

        public SimpleTile(Tile tile)
        {
            _tile = tile;
        }

        public bool IsMovable => true;

        public void Begin()
        {
            var sprite = General.Instance.GameResources.TileSimpleSprite;
            _tile.SetTileSprite(sprite);
        }

        public void Blow() => _tile.Stone?.Blow();

        public void End() { }

        public int GetStoneID()
        {
            int result;
            if (_tile.Stone == null)
                result = -1;
            else
                result = _tile.Stone.ID;
            return result;
        }

        public bool NeedStone() => _tile.Stone == null;
    }
}