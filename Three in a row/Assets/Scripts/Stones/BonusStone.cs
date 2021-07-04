using System;
using UnityEngine;

namespace ThreeInARow.Stones
{
    public abstract class BonusStone : IStone
    {
        public bool _activated = false;

        public event Action Destroyed;

        private Sprite _sprite;
        private int _id;

        public Sprite Sprite => _sprite;
        public int ID => _id;

        public void Blow()
        {
            if (_activated) Destroyed.Invoke();
            else UseBonus();
        }

        protected abstract void UseBonus();
    }
}