using ThreeInARow.Boards.States;
using ThreeInARow.Tiles;
using UnityEngine;

namespace ThreeInARow.Boards
{
    public class Board
    {
        private readonly BoardCreator _creator;

        private Tile[,] _tiles;
        private IBoardState _state;
        private Vector2Int _size;
        private int _countReadyTile;

        public Tile[,] Tiles => _tiles;
        public int Width => _size.x;
        public int Height => _size.y;

        public Board()
        {
            _creator = new BoardCreator();
        }

        public void FillBoard(Vector2Int size)
        {
            _size = size;
            _tiles = _creator.Create(size, this);

            for (var x = 0; x < size.x; x++)
            {
                for (var y = 0; y < size.y; y++)
                {
                    _tiles[x, y].Ready += OnTileReady;
                    _tiles[x, y].NotReady += OnTileNotReady;
                }
            }

            ChangeState(new WaitState(this));
            NextStep();
        }

        public void TileClick(Tile tile) => _state.TileClick(tile);

        public void ChangeState(IBoardState state)
        {
            _state?.End();
            _state = state;
            _state.Begin();
        }

        public void NextStep() => _state.NextStep();

        public void OnTileReady()
        {
            if (++_countReadyTile == _size.x * _size.y)
                NextStep();
        }

        public void OnTileNotReady()
        {
            _countReadyTile--;
        }
    }
}