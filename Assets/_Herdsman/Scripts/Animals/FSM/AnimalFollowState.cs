using Herdsman.FSM;

namespace Herdsman.Animals
{
    public class AnimalFollowState : IState<AnimalState>
    {
        private readonly IAnimal _animal;

        public AnimalFollowState(IAnimal animal)
        {
            _animal = animal;
        }

        public bool CanChange(AnimalState nextState)
        {
            return false;
        }

        public void Enter()
        {
            // add to herd maybe using signal bus
        }

        public AnimalState Execute()
        {
            return AnimalState.Follow;
        }

        public void Exit()
        {
        }
    }
}