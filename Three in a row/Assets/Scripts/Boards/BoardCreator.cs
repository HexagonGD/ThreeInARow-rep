using ThreeInARow.Managers;
using ThreeInARow.Tiles;
using ThreeInARow.Tiles.States;
using UnityEngine;

namespace ThreeInARow.Boards
{
    public class BoardCreator
    {
        private readonly Tile _tilePrefab;
        private readonly Transform _tileStock;

        public BoardCreator()
        {
            _tileStock = new GameObject("TileStock").transform;
            _tilePrefab = General.Instance.GameResources.TilePrefab;
        }

        public Tile[,] Create(Vector2Int size, Board board)
        {
            var tiles = new Tile[size.x, size.y];
            _tileStock.position = new Vector2(-size.x / 2, -size.y / 2);
            Vector2 position;

            for (var x = 0; x < size.x; x++)
            {
                position.x = x;
                for (var y = 0; y < size.y; y++)
                {
                    position.y = y;
                    Tile tile = Object.Instantiate(_tilePrefab, _tileStock);
                    tiles[x, y] = tile;
                    tile.transform.localPosition = position;
                    tile.board = board;
                    SetRandomTileState(tile);
                }
            }
            return tiles;
        }

        private void SetRandomTileState(Tile tile)
        {
            if (Random.value < 0.8f)
                tile.ChangeState(new SimpleTile(tile));
            else if (Random.value < 0.8f)
                tile.ChangeState(new FreezeTile(tile));
            else
                tile.ChangeState(new StoneTile(tile));
        }
    }
}