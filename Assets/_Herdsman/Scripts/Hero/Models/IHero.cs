using System;
using UnityEngine;
using Herdsman.Animals;

namespace Herdsman.Player
{
    public interface IHero : IDisposable
    {
        Action<Vector2> OnchangePosition { get; set; }
        Vector2 TargetPosition { get; }
        float CollectRange { get; }
        void Collect(IAnimal animal);
        void Move(Vector2 currentPosition);
    }
}