using System;
using UnityEngine;

namespace ThreeInARow.Stones
{
    public class SimpleStone : IStone
    {
        public event Action Destroyed;

        public Sprite Sprite { get; private set; }
        public int ID { get; private set; }

        public SimpleStone(StoneInfo info)
        {
            Sprite = info.Sprite;
            ID = info.ID;
        }

        public void Blow()
        {
            Destroyed?.Invoke();
        }
    }
}