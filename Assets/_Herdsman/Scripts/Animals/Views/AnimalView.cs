using OsirisGames.EventBroker;
using System;
using UnityEngine;

namespace Herdsman.Animals
{
    public class AnimalView : MonoBehaviour, IAnimalView
    {
        private IAnimal _animal;
        private IEventBus _signalBus;

        public void Init(IAnimal animal, IEventBus signalBus)
        {
            _animal = animal ?? throw new ArgumentNullException(nameof(animal));
            _signalBus = signalBus ?? throw new ArgumentNullException(nameof(signalBus));

            _animal.OnchangePosition += ChangePosition;
        }

        private void ChangePosition(Vector3 newPosition)
        {
            transform.position = newPosition;
        }

        private void Update()
        {
            _animal?.Tick();
        }

        public void Collect()
        {
            _signalBus.Fire(new AnimalCollectInYardSignal(_animal));
        }

        public void TryFollow()
        {
            _signalBus.Fire(new AnimalFollowPlayer(_animal));
        }

        private void OnDestroy()
        {
            _animal.OnchangePosition -= ChangePosition;
        }
    }
}