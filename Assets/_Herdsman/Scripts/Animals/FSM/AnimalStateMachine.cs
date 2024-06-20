using Herdsman.FSM;
using Herdsman.PositionProviders;

namespace Herdsman.Animals
{
    public class AnimalStateMachine : FiniteStateMachine<AnimalState>
    {
        public AnimalStateMachine(IAnimal animal, IPositionProvider positionProvider, IMovement movement)
        {
            AddState(AnimalState.Idle, new AnimalIdleState(animal));
            AddState(AnimalState.Patrol, new AnimalPatrolState(animal, positionProvider, movement));
            AddState(AnimalState.Follow, new AnimalFollowState(animal));
        }
    }
}