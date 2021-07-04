using System;
using ThreeInARow.Boards;
using ThreeInARow.Stones;
using ThreeInARow.Tiles.States;
using UnityEngine;

namespace ThreeInARow.Tiles
{
    public class Tile : MonoBehaviour
    {
        private const float _speed = 1.5f;

        public Board board;

        [SerializeField] private SpriteRenderer _tileRenderer;
        [SerializeField] private SpriteRenderer _stoneRenderer;
        private IStone _stone;
        private ITileState _state;
        private bool _isReady;

        public event Action Blowed;
        public event Action Ready;
        public event Action NotReady;

        public IStone Stone => _stone;
        public bool IsReady => _isReady;

        private void Update()
        {
            if (_stoneRenderer.transform.position == transform.position)
            {
                if (!_isReady)
                {
                    _isReady = true;
                    Ready?.Invoke();
                }
            }
            else
            {
                if (_isReady)
                {
                    _isReady = false;
                    NotReady?.Invoke();
                }
                _stoneRenderer.transform.position = Vector3.MoveTowards
                    (_stoneRenderer.transform.position, transform.position, _speed * Time.deltaTime);
            }
        }

        public static bool ChangeStone(Tile tileA, Tile tileB)
        {
            if (tileA.Stone == null && tileB.Stone == null) return false;

            IStone stone = tileA._stone;
            tileA.ChangeStone(tileB._stone, tileB.transform.position);
            tileB.ChangeStone(stone, tileA.transform.position);
            return true;
        }

        #region State Methods
        public void Blow() => _state.Blow();

        public bool NeedStone() => _state.NeedStone();

        public int GetStoneID() => _state.GetStoneID();
        #endregion

        public void ChangeState(ITileState state)
        {
            this._state?.End();
            this._state = state;
            this._state.Begin();
        }

        public void SetTileSprite(Sprite sprite)
        {
            _tileRenderer.sprite = sprite;
        }
        
        public void ChangeStone(IStone stone, Vector3 position)
        {
            if (this._stone != null)
            {
                this._stone.Destroyed -= OnStoneDestroyed;
            }

            if(stone != null)
            {
                _stoneRenderer.sprite = stone.Sprite;
                stone.Destroyed += OnStoneDestroyed;
            }
            else
            {
                _stoneRenderer.sprite = null;
            }

            this._stone = stone;
            _stoneRenderer.transform.position = position;
        }

        #region Handlers Events

        public void OnClick()
        {
            if(_state.IsMovable)
                board.TileClick(this);
        }

        public void OnStoneDestroyed()
        {
            ChangeStone(null, transform.position);
        }

        private void OnDestroy()
        {
            Ready = null;
            NotReady = null;
            Blowed = null;
        }

        #endregion
    }
}