using OsirisGames.EventBroker;
using System;
using UnityEngine;

namespace Herdsman.Animals
{
    public class AnimalView : MonoBehaviour, IAnimalView
    {
        private IAnimal _animal;
        private IEventBus _signalBus;

        public Transform Transform { get; private set; }

        private void Awake()
        {
            Transform = transform;
        }

        public void Init(IAnimal animal, IEventBus signalBus)
        {
            _animal = animal ?? throw new ArgumentNullException(nameof(animal), "Animal cannot be null.");
            _signalBus = signalBus ?? throw new ArgumentNullException(nameof(signalBus), "SignalBus cannot be null.");

            _animal.OnchangePosition += ChangePosition;

            _animal.Reset();
        }

        private void ChangePosition(Vector2 newPosition)
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
            _signalBus.Fire(new AnimalFollowPlayerSignal(_animal));
        }

        private void OnDestroy()
        {
            _animal.OnchangePosition -= ChangePosition;
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}