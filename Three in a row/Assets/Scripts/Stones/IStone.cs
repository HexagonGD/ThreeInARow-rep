using System;
using UnityEngine;

namespace ThreeInARow.Stones
{
    public interface IStone
    {
        event Action Destroyed;
        void Blow();
        Sprite Sprite { get; }
        int ID { get; }
    }
}