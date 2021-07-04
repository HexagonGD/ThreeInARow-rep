using System;
using UnityEngine;

namespace ThreeInARow.Stones
{
    public abstract class UpgradeStone : IStone
    {
        private Sprite _sprite;
        private int _id;

        public Sprite Sprite => _sprite;
        public int ID => _id;

        public event Action Destroyed;

        public void Blow()
        {
            Upgrade();
        }

        protected abstract void Upgrade();
    }
}