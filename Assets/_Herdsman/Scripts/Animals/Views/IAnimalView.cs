using OsirisGames.EventBroker;
using UnityEngine;

namespace Herdsman.Animals
{
    public interface IAnimalView
    {
        Transform Transform { get; }
        void Init(IAnimal animal, IEventBus signalBus);
        void Activate();
        void Deactivate();
        void Collect();
        void TryFollow();
    }
}