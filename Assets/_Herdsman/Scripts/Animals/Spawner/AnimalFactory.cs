using Herdsman.PositionProviders;
using OsirisGames.EventBroker;
using System;
using System.Collections.Generic;

namespace Herdsman.Animals
{
    public class AnimalFactory : IAnimalFactory
    {
        private readonly IPositionProvider _positionProvider;
        private readonly IPositionProvider _heroPositionProvider;
        private readonly IAnimalData _animalConfig;
        private readonly IEventBus _signalBus;
        private readonly Dictionary<IAnimal, IAnimalView> _map;
        private readonly AnimalBuilder _animalBuilder;

        public AnimalFactory(IPositionProvider positionProvider, IPositionProvider heroPositionProvider, IAnimalData animalConfig, IEventBus signalBus)
        {
            _positionProvider = positionProvider ?? throw new ArgumentNullException(nameof(positionProvider), "Position provider cannot be null.");
            _heroPositionProvider = heroPositionProvider ?? throw new ArgumentNullException(nameof(heroPositionProvider), "Hero position provider cannot be null.");
            _animalConfig = animalConfig ?? throw new ArgumentNullException(nameof(animalConfig), "Animal configuration cannot be null.");
            _signalBus = signalBus ?? throw new ArgumentNullException(nameof(signalBus), "Signal bus cannot be null.");
            _map = new Dictionary<IAnimal, IAnimalView>();

            _animalBuilder = new AnimalBuilder(_positionProvider, _heroPositionProvider, _animalConfig);
        }

        public void CreateAnimal(IAnimalView animalView)
        {
            if (animalView == null)
            {
                throw new ArgumentNullException(nameof(animalView), "Animal view cannot be null.");
            }

            var animal = _animalBuilder
                .WithStateMachine()
                .WithMovement(new MoveTowardsObjectMovement(animalView.Transform, _animalConfig.Speed))
                .Build();

            animalView.Init(animal, _signalBus);
            _map[animal] = animalView;
        }

        public void ResetAnimal(IAnimal animal)
        {
            if (animal == null)
            {
                throw new ArgumentNullException(nameof(animal), "Animal cannot be null.");
            }

            if (_map.TryGetValue(animal, out var view))
            {
                view.Deactivate();
                animal.Reset();
            }
            else
            {
                throw new KeyNotFoundException("The specified animal was not found in the factory.");
            }
        }

        public IAnimalView GetAnimalView(IAnimal animal)
        {
            if (animal == null)
            {
                throw new ArgumentNullException(nameof(animal), "Animal cannot be null.");
            }

            if (_map.TryGetValue(animal, out var view))
            {
                return view;
            }

            throw new KeyNotFoundException(nameof(animal));
        }
    }
}