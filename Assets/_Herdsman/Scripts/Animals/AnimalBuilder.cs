using Herdsman.PositionProviders;

namespace Herdsman.Animals
{
    public class AnimalBuilder
    {
        private readonly IPositionProvider _positionProvider;
        private readonly IMovement _movement;
        private readonly IAnimalData _animalData;
        private bool _useStateMachine;

        public AnimalBuilder(IPositionProvider positionProvider, IMovement movement, IAnimalData animalData)
        {
            _positionProvider = positionProvider;
            _movement = movement;
            _animalData = animalData;
            _useStateMachine = false;
        }

        public AnimalBuilder WithStateMachine()
        {
            _useStateMachine = true;
            return this;
        }

        public IAnimal Build()
        {
            var animal = new Animal(_animalData);

            if (_useStateMachine)
            {
                var stateMachine = new AnimalStateMachine(animal, _positionProvider, _movement);
                return new AnimalWithStateMachine(animal, stateMachine);
            }

            return animal;
        }
    }
}