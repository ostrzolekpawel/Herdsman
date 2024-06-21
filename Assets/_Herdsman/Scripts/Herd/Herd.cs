using System;
using System.Collections.Generic;
using Herdsman.Animals;
using OsirisGames.EventBroker;

namespace Herdsman
{
    public class Herd : IHerd
    {
        private readonly int _capacity;
        private readonly List<IAnimal> _animals;
        private readonly IEventBus _signalBus;

        public Herd(IHerdData config, IEventBus signalBus)
        {
            _animals = new List<IAnimal>();
            _capacity = config.Capacity;
            _signalBus = signalBus;

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