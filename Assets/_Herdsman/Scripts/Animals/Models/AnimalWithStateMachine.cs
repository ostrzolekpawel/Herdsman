using Herdsman.FSM;
using System;
using UnityEngine;

namespace Herdsman.Animals
{
    public class AnimalWithStateMachine : IAnimal
    {
        private readonly IAnimal _animal;
        private readonly IFinishStateMachine<AnimalState> _stateMachine;

        public AnimalWithStateMachine(IAnimal animal, IFinishStateMachine<AnimalState> stateMachine)
        {
            _animal = animal ?? throw new ArgumentNullException(nameof(animal), "Animal cannot be null.");
            _stateMachine = stateMachine ?? throw new ArgumentNullException(nameof(stateMachine), "StateMachine cannot be null.");
        }

        public Action<Vector3> OnchangePosition
        {
            get => _animal.OnchangePosition;
            set => _animal.OnchangePosition = value;
        }

        public int Points => _animal.Points;
        public float Speed => _animal.Speed;

        public void Tick()
        {
            _animal.Tick();
            _stateMachine.Execute();
        }

        public void Move(Vector3 newPosition)
        {
            _animal.Move(newPosition);
        }

        public void Follow()
        {
            _stateMachine.ChangeState(AnimalState.Follow);
        }

        public void Reset()
        {
            _animal.Reset();
            _stateMachine.ChangeState(AnimalState.Idle);
        }
    }
}