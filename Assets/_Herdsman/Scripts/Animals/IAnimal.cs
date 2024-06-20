using System;
using UnityEngine;

namespace Herdsman.Animals
{
    public interface IAnimal
    {
        Action<Vector3> OnchangePosition { get; set; }
        int Points { get; }
        float Speed { get; }
        void Tick();
        void Follow();
        void Move(Vector3 position);
    }
}