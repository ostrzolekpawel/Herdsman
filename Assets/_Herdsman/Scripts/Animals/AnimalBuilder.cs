using Herdsman.Movement;
using Herdsman.PositionProviders;
using System;

namespace Herdsman.Animals
{
    public class AnimalBuilder
    {
        private readonly IPositionProvider _positionProvider;
        private readonly IPositionProvider _heroPositionProvider;
        private readonly IAnimalData _animalData;

        private bool _useStateMachine;
        private IMovement _movement;

        public AnimalBuilder(IPositionProvider positionProvider, IPositionProvider heroPositionProvider, IAnimalData animalData)
        {
            _positionProvider = positionProvider ?? throw new ArgumentNullException(nameof(positionProvider), "PositionProvider cannot be null.");
            _heroPositionProvider = heroPositionProvider ?? throw new ArgumentNullException(nameof(heroPositionProvider), "HeroPositionProvider cannot be null.");
            _animalData = animalData ?? throw new ArgumentNullException(nameof(animalData), "AnimalData cannot be null.");
            _useStateMachine = false;

            _movement = new TeleportMovement(); // default movement
        }

        public AnimalBuilder WithStateMachine()
        {
            _useStateMachine = true;
            return this;
        }

        public AnimalBuilder WithMovement(IMovement movement)
        {
            _movement = movement;
            return this;
        }

        public IAnimal Build()
        {
            var animal = new Animal(_animalData, _positionProvider);

            if (_useStateMachine)
            {
                var stateMachine = new AnimalStateMachine(animal, _positionProvider, _heroPositionProvider, _movement);
                return new AnimalWithStateMachine(animal, stateMachine);
            }

            return animal;
        }
    }
}