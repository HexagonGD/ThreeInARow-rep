using ThreeInARow.Managers;

namespace ThreeInARow.Tiles.States
{
    public class FreezeTile : ITileState
    {
        private Tile _tile;

        public FreezeTile(Tile tile)
        {
            _tile = tile;
        }

        public bool IsMovable => false;

        public void Begin()
        {
            var sprite = General.Instance.GameResources.TileFreezeSprite;
            _tile.SetTileSprite(sprite);
        }

        public void Blow()
        {
            var state = new SimpleTile(_tile);
            _tile.ChangeState(state);
        }

        public bool NeedStone() => _tile.Stone == null;

        public void End() { }

        public int GetStoneID() => _tile.Stone == null ? -1 : _tile.Stone.ID;
    }
}