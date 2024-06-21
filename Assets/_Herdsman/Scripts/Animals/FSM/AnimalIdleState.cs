using Herdsman.FSM;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Herdsman.Animals
{
    public class AnimalIdleState : IState<AnimalState>
    {
        private readonly List<AnimalState> _allowedTransitions = new List<AnimalState> { AnimalState.Patrol, AnimalState.Follow };
        private float _idleTime;
        private const float IDLE_DURATION = 2f;

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