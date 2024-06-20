using Herdsman.FSM;
using Herdsman.PositionProviders;
using System.Collections.Generic;
using UnityEngine;

namespace Herdsman.Animals
{
    public class AnimalFollowState : IState<AnimalState>
    {
        private readonly List<AnimalState> _allowedTransitions = new List<AnimalState> { AnimalState.Idle };
        private readonly IAnimal _animal;
        private readonly IPositionProvider _heroPositionProvider;
        private readonly IMovement _movement;

        public AnimalFollowState(IAnimal animal, IPositionProvider heroPositionProvider, IMovement movement)
        {
            _animal = animal;
            _heroPositionProvider = heroPositionProvider;
            _movement = movement;
        }

        public bool CanChange(AnimalState nextState)
        {
            return _allowedTransitions.Contains(nextState);
        }

        public void Enter()
        {
            Debug.Log("Entering Follow State");
        }

        public AnimalState Execute()
        {
            var heroPosition = _heroPositionProvider.GetPosition();
            var newPosition = _movement.Move(heroPosition);

            _animal.Move(newPosition);
            return AnimalState.Follow;
        }

        public void Exit()
        {
        }
    }
}