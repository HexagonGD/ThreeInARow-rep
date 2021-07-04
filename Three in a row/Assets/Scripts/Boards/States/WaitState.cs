using ThreeInARow.Boards.States;
using ThreeInARow.Stones;
using ThreeInARow.Tiles;
using ThreeInARow.Managers;
using UnityEngine;

namespace ThreeInARow.Boards
{
    internal class WaitState : IBoardState
    {
        private Board _board;
        private StoneConfig _stoneConfig;

        public WaitState(Board board)
        {
            _board = board;
            _stoneConfig = General.Instance.GameResources.StoneConfig;
        }

        public void Begin()
        {
            Debug.Log("Wait State");
        }

        public void End() { }

        public bool TileClick(Tile tile) => false;

        public void NextStep()
        {
            TryCalculateCombination();
            if (!TryFallStones())
                _board.ChangeState(new PlayState(_board));
        }

        #region Calculate Combination Methods
        public void TryCalculateCombination()
        {
            for (var x = 0; x < _board.Width; x++)
                for (var y = _board.Height - 1; y > -1; y--)
                    if (_board.Tiles[x, y].NeedStone())
                        return;
                    else if (_board.Tiles[x, y].Stone == null)
                        break;

            CalculateCombination();
        }

        public void CalculateCombination()
        {
            int[,] hits = new int[_board.Width, _board.Height];

            for (var x = 0; x < _board.Width; x++)
            {
                int lastID = -1;
                int count = 0;

                for (var y = 0; y < _board.Height; y++)
                {
                    if (CompareID(ref lastID, _board.Tiles[x, y]))
                    {
                        count++;
                    }
                    else
                    {
                        AddVerticalBlow(ref hits, y - count, y, x);
                        count = lastID == -1 ? 0 : 1;
                    }
                }

                AddVerticalBlow(ref hits, _board.Height - count, _board.Height, x);
            }

            for (var y = 0; y < _board.Height; y++)
            {
                int lastID = -1;
                int count = 0;

                for (var x = 0; x < _board.Width; x++)
                {
                    if (CompareID(ref lastID, _board.Tiles[x, y]))
                    {
                        count++;
                    }
                    else
                    {
                        AddHorizontalBlow(ref hits, x - count, x, y);
                        count = lastID == -1 ? 0 : 1;
                    }
                }

                AddHorizontalBlow(ref hits, _board.Width - count, _board.Width, y);
            }

            for (var x = 0; x < _board.Width; x++)
                for (var y = 0; y < _board.Height; y++)
                    if (hits[x, y] > 0)
                        _board.Tiles[x, y].Blow();
        }

        public void AddVerticalBlow(ref int[,] hits, int begin, int end, int x)
        {
            if (end - begin < 3) return;

            for (var y = begin; y < end; y++)
                hits[x, y]++;
        }

        public void AddHorizontalBlow(ref int[,] hits, int begin, int end, int y)
        {
            if (end - begin < 3) return;

            for (var x = begin; x < end; x++)
                hits[x, y]++;
        }
        #endregion

        #region Fall Methods
        public bool TryFallStones()
        {
            bool isFall = false;

            for (var x = 0; x < _board.Width; x++)
                for (var y = 0; y < _board.Height; y++)
                    if (_board.Tiles[x, y].NeedStone())
                        isFall = Fall(x, y) || isFall;

            return isFall;
        }

        public bool Fall(int x, int y)
        {
            var result = false;

            if (y == _board.Height - 1)
            {
                _board.Tiles[x, y].ChangeStone(new SimpleStone(_stoneConfig.GetRandom()),
                    _board.Tiles[x, y].transform.position + Vector3.up);
                result = true;
            }
            else
            {
                result = Tile.ChangeStone(_board.Tiles[x, y], _board.Tiles[x, y + 1]);
            }

            return result;
        }
        #endregion

        public bool CompareID(ref int lastID, Tile tile)
        {
            int id = tile.GetStoneID();
            bool result;

            if (id == -1)
            {
                lastID = -1;
                result = false;
            }
            else if (id == lastID)
            {
                result = true;
            }
            else
            {
                lastID = id;
                result = false;
            }

            return result;
        }
    }
}