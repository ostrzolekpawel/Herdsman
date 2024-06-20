using OsirisGames.EventBroker;

namespace Herdsman.Player
{
    public class HeroBuilder
    {
        private readonly IHeroData _heroData;
        private readonly IMovement _movement;
        private readonly IHerd _herd;
        private readonly IEventBus _eventBus;

        public HeroBuilder(IHeroData heroData, IMovement movement, IHerd herd, IEventBus eventBus)
        {
            _heroData = heroData;
            _movement = movement;
            _herd = herd;
            _eventBus = eventBus;
        }

        public IHero Build()
        {
            return new Hero(_heroData, _herd, _movement, _eventBus);
        }
    }
}