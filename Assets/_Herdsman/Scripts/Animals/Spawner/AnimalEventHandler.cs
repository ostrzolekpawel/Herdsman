using OsirisGames.EventBroker;
using System;

namespace Herdsman.Animals
{
    public class AnimalEventHandler : IDisposable
    {
        private readonly IEventBus _signalBus;
        private readonly IAnimalFactory _animalFactory;
        private readonly IAnimalPool _animalPool;

        public AnimalEventHandler(IEventBus signalBus, IAnimalFactory animalFactory, IAnimalPool animalPool)
        {
            _signalBus = signalBus;
            _animalFactory = animalFactory;
            _animalPool = animalPool;
            _signalBus.Subscribe<AnimalCollectInYardSignal>(OnAnimalCollected);
        }

        private void OnAnimalCollected(AnimalCollectInYardSignal signal)
        {
            var animal = signal.Animal;
            if (animal != null)
            {
                var view = _animalFactory.GetAnimalView(animal);
                _animalPool.ReleaseToPool(view);
                _animalFactory.ResetAnimal(animal);

            }
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<AnimalCollectInYardSignal>(OnAnimalCollected);
        }
    }
}