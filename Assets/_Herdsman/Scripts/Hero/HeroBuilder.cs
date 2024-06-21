using Herdsman.Herds;
using Herdsman.Movement;
using OsirisGames.EventBroker;
using System;

namespace Herdsman.Player
{
    public class HeroBuilder
    {
        private readonly IHeroData _heroData;
        private readonly IMovement _movement;
        private readonly IHerd _herd;
        private readonly IEventBus _signalBus;

        public HeroBuilder(IHeroData heroData, IMovement movement, IHerd herd, IEventBus signalBus)
        {
            _heroData = heroData ?? throw new ArgumentNullException(nameof(heroData), "HeroData cannot be null.");
            _movement = movement ?? throw new ArgumentNullException(nameof(movement), "Movement cannot be null.");
            _herd = herd ?? throw new ArgumentNullException(nameof(herd), "Herd cannot be null.");
            _signalBus = signalBus ?? throw new ArgumentNullException(nameof(signalBus), "SignalBus cannot be null.");
        }

        public IHero Build()
        {
            return new Hero(_heroData, _herd, _movement, _signalBus);
        }
    }
}