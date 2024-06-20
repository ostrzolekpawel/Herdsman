using Herdsman.FSM;
using Herdsman.PositionProviders;
using System.Collections.Generic;
using UnityEngine;

namespace Herdsman.Animals
{
    public class AnimalPatrolState : IState<AnimalState>
    {
        private readonly List<AnimalState> _allowedTransitions = new List<AnimalState> { AnimalState.Idle, AnimalState.Follow };
        private readonly IAnimal _animal;
        private readonly IPositionProvider _positionProvider;
        private readonly IMovement _movement;
        private Vector2 _targetPosition;

        public AnimalPatrolState(IAnimal animal, IPositionProvider positionProvider, IMovement movement)
        {
            _animal = animal;
            _positionProvider = positionProvider;
            _movement = movement;
        }

        public void Enter()
        {
            Debug.Log("Entering Patrol State");
            _targetPosition = _positionProvider.GetPosition();
        }

        public AnimalState Execute()
        {
            var newPosition = _movement.Move(_targetPosition);
            if (Vector2.Distance(newPosition, _targetPosition) < 0.001f)
            {
                return AnimalState.Idle;
            }

            _animal.Move(newPosition);
            return AnimalState.Patrol;
        }

        public void Exit()
        {
            Debug.Log("Exiting Patrol State");
        }

        public bool CanChange(AnimalState nextState)
        {
            return _allowedTransitions.Contains(nextState);
        }
    }
}