using ThreeInARow.Boards.States;
using ThreeInARow.Tiles;
using UnityEngine;

namespace ThreeInARow.Boards
{
    public class PlayState : IBoardState
    {
        private Board _board;
        private Tile _lastClickTile;

        public PlayState(Board board)
        {
            _board = board;
        }

        public void Begin()
        {
            Debug.Log("Play State");
        }

        public void End()
        {
            return;
        }

        public void NextStep()
        {
            return;   
        }

        public bool TileClick(Tile tile)
        {
            bool successClick = true;

            if (_lastClickTile == null)
            {
                _lastClickTile = tile;
            }
            else if (tile == _lastClickTile)
            {
                _lastClickTile = null;
                successClick = false;
            }
            else
            {
                if (Tile.ChangeStone(_lastClickTile, tile))
                {
                    _board.ChangeState(new WaitState(_board));
                }
            }
                
            return successClick;
        }
    }
}