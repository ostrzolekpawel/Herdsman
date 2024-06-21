using System;
using System.Collections.Generic;
using Herdsman.Animals;
using OsirisGames.EventBroker;

namespace Herdsman.Herds
{
    public class Herd : IHerd
    {
        private readonly int _capacity;
        private readonly List<IAnimal> _animals;
        private readonly IEventBus _signalBus;

        public Herd(IHerdData data, IEventBus signalBus)
        {
            if (data == null)
            {
                 throw new ArgumentNullException(nameof(data), "Herd Data cannot be null.");
            }

            _animals = new List<IAnimal>();
            _capacity = data.Capacity;
            _signalBus = signalBus ?? throw new ArgumentNullException(nameof(signalBus), "SignalBus cannot be null.");

            _signalBus.Subscribe<AnimalCollectInYardSignal>(ReleaseFromHerd);
        }

        private void ReleaseFromHerd(AnimalCollectInYardSignal signal)
        {
            Release(signal.Animal);
        }

        public void Collect(IAnimal animal)
        {
            if (_animals.Count >= _capacity)
            {
                return;
            }

            _animals.Add(animal);
            animal.Follow();
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<AnimalCollectInYardSignal>(ReleaseFromHerd);
        }

        public void Release(IAnimal animal)
        {
            if (_animals.Contains(animal))
            {
                _animals.Remove(animal);
            }
        }
    }
}