using Herdsman.PositionProviders;
using System;
using UnityEngine;

namespace Herdsman.Animals
{
    public class Animal : IAnimal
    {
        private readonly IPositionProvider _positionProvider;

        public Action<Vector3> OnchangePosition { get; set; }
        public int Points { get;}
        public float Speed { get; }

        public Animal(IAnimalData data, IPositionProvider positionProvider)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "Animal data cannot be null.");
            }

            Points = data.Points;
            Speed = data.Speed;
            _positionProvider = positionProvider ?? throw new ArgumentNullException(nameof(positionProvider), "PositionProvider cannot be null.");
        }

        public void Tick()
        {
        }

        public void Follow()
        {
        }

        public void Reset()
        {
            Move(_positionProvider.GetPosition());
        }

        public void Move(Vector3 newPosition)
        {
            OnchangePosition?.Invoke(newPosition);
        }
    }
}