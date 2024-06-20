using OsirisGames.EventBroker;
using UnityEngine;

namespace Herdsman.Player
{
    public class HeroCreator : MonoBehaviour
    {
        [SerializeField] private HeroView _heroView;
        [SerializeField] private HeroDataConfig _heroDataConfig;

        private IMovement _movement;

        private void Awake()
        {
            _movement = new MoveTowardsObjectMovement(_heroView.transform, _heroDataConfig.Speed);
        }

        public void Init(IEventBus signalBus, IHerd herd)
        {
            var hero = new HeroBuilder(_heroDataConfig, _movement, herd, signalBus).Build();

            _heroView.Init(hero);
        }

        public void Tick()
        {
            _heroView.Tick();
        }
    }
}