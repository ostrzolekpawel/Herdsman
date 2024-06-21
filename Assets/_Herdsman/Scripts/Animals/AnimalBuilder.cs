using Herdsman.PositionProviders;

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
            _positionProvider = positionProvider;
            _heroPositionProvider = heroPositionProvider;
            _animalData = animalData;
            _useStateMachine = false;

            _movement = new TeleportMovement();
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