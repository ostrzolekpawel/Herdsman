using Herdsman.Animals;
using Herdsman.Utils;
using OsirisGames.EventBroker;

namespace Herdsman.Stats
{
    public class GameStats : IGameStats
    {
        private readonly IEventBus _signalBus;

        public NotifiableValue<int> Score { get; } = new NotifiableValue<int>(0);

        public GameStats(IEventBus signalBus)
        {
            _signalBus = signalBus;
            _signalBus.Subscribe<AnimalCollectInYardSignal>(IncreaseScore);
        }

        private void IncreaseScore(AnimalCollectInYardSignal signal)
        {
            AddScore(signal.Animal.Points);
        }

        public void AddScore(int additionalScore)
        {
            Score.Value += additionalScore;
        }

        public void UpdateScore(int newScore)
        {
            Score.Value = newScore;
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<AnimalCollectInYardSignal>(IncreaseScore);
        }
    }
}