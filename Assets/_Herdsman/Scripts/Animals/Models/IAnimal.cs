using System;
using UnityEngine;

namespace Herdsman.Animals
{
    public interface IAnimal
    {
        Action<Vector2> OnchangePosition { get; set; }
        int Points { get; }
        float Speed { get; }
        void Tick();
        void Follow();
        void Move(Vector2 position);
        void Reset();
    }
}