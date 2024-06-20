using System;
using UnityEngine;

namespace Herdsman.Animals
{
    public class Animal : IAnimal
    {
        public Action<Vector3> OnchangePosition { get; set; }

        public int Points { get;}

        public float Speed { get; }

        public Animal(IAnimalData data)
        {
            Points = data.Points;
            Speed = data.Speed;
        }

        public void Tick()
        {
        }

        public void Follow()
        {
        }

        public void Move(Vector3 newPosition)
        {
            OnchangePosition?.Invoke(newPosition);
        }
    }
}