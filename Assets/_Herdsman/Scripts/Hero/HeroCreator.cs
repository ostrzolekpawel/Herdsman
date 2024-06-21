using Herdsman.Herds;
using OsirisGames.EventBroker;
using UnityEngine;

namespace Herdsman.Player
{
    public class HeroCreator : MonoBehaviour
    {
        [SerializeField] private HeroView _heroView;
        [SerializeField] private HeroDataConfig _heroDataConfig;
        [SerializeField] private HerdDataConfig _herdDataConfig;

        private IMovement _movement;

        public void Init(IEventBus signalBus)
        {
            _movement = new MoveTowardsObjectMovement(_heroView.transform, _heroDataConfig.Speed);
            var herd = new Herd(_herdDataConfig, signalBus);
            var hero = new HeroBuilder(_heroDataConfig, _movement, herd, signalBus).Build();

            _heroView.Init(hero);
        }

        public void Tick()
        {
            _heroView.Tick();
        }
    }
}