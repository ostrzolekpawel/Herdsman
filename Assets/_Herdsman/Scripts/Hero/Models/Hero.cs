using System;
using UnityEngine;
using Herdsman.Animals;
using OsirisGames.EventBroker;
using Herdsman.Herds;

namespace Herdsman.Player
{
    public class Hero : IHero
    {
        private readonly IHerd _herd;
        private readonly IMovement _movement;
        private readonly IEventBus _signalBus;

        public Action<Vector2> OnchangePosition { get; set; }
        public float CollectRange { get; }
        public Vector2 TargetPosition { get; private set; }

        public Hero(IHeroData data, IHerd herd, IMovement movement, IEventBus signalBus)
        {
            _herd = herd;
            _movement = movement;
            _signalBus = signalBus;

            CollectRange = data.CollectRange;

            _signalBus.Subscribe<MoveHeroToTargetSignal>(TakeTargetPosition);
            _signalBus.Subscribe<AnimalFollowPlayerSignal>(CollectAnimalToHerd);
        }

        private void CollectAnimalToHerd(AnimalFollowPlayerSignal signal)
        {
            Collect(signal.Animal);
        }

        private void TakeTargetPosition(MoveHeroToTargetSignal signal)
        {
            TargetPosition = signal.TargerPosition;
        }

        public void Collect(IAnimal animal)
        {
            _herd.Collect(animal);
        }

        public void Move(Vector2 currentPosition)
        {
            var newPosition = _movement.Move(TargetPosition);
            OnchangePosition?.Invoke(newPosition);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<MoveHeroToTargetSignal>(TakeTargetPosition);
            _signalBus.Unsubscribe<AnimalFollowPlayerSignal>(CollectAnimalToHerd);

            _herd.Dispose();
        }
    }
}