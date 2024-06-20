using OsirisGames.EventBroker;
using UnityEngine;

namespace Herdsman.Animals
{
    public class AnimalView : MonoBehaviour, IAnimalView
    {
        private IEventBus _signalBus;

        private IAnimal _animal;

        public void Init(IAnimal animal, IEventBus signalBus)
        {
            _animal = animal;
            _animal.OnchangePosition += ChangePosition;

            _signalBus = signalBus;
        }

        private void ChangePosition(Vector3 newPosition)
        {
            transform.position = newPosition;
        }

        private void Update()
        {
            _animal?.Tick();
        }

        public void Collect()
        {
            _signalBus.Fire(new CollectAnimalSignal(_animal));
        }
    }
}