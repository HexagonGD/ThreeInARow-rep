using System;
using ThreeInARow.Boards;
using UnityEngine;

namespace ThreeInARow.Managers
{
    public class Starter : MonoBehaviour
    {
        [SerializeField] private Vector2Int _size;

        private void Awake()
        {
            var board = new Board();
            board.FillBoard(_size);
        }
    }
}