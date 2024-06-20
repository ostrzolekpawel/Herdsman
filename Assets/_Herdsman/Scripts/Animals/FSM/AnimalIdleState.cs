using Herdsman.FSM;
using System.Collections.Generic;
using UnityEngine;

namespace Herdsman.Animals
{
    public class AnimalIdleState : IState<AnimalState>
    {
        private readonly List<AnimalState> _allowedTransitions = new List<AnimalState> { AnimalState.Patrol, AnimalState.Follow };
        private readonly IAnimal _animal;
        private float _idleTime;
        private const float IDLE_DURATION = 5f;

        public AnimalIdleState(IAnimal animal)
        {
            _animal = animal;
        }

        public void Enter()
        {
            Debug.Log("Entering Idle State");
            _idleTime = 0f;
        }

        public AnimalState Execute()
        {
            _idleTime += Time.deltaTime;

            if (_idleTime >= IDLE_DURATION)
            {
                return AnimalState.Patrol;
            }

            return AnimalState.Idle;
        }

        public void Exit()
        {
            Debug.Log("Exiting Idle State");
        }

        public bool CanChange(AnimalState nextState)
        {
            return _allowedTransitions.Contains(nextState);
        }
    }
}