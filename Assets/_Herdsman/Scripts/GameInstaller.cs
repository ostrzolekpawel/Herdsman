using OsirisGames.EventBroker;
using UnityEngine;
using Herdsman.Animals;
using Herdsman.Player;

namespace Herdsman
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private AnimalSpawner _animalSpawner;
        [SerializeField] private HeroCreator _heroCreator;
        [SerializeField] private MouseInputReader _inputReader;
        [SerializeField] private GameStatsView _gameStatsView;

        [SerializeField] private AnimalSpawnerDataConfig _animalSpawnerData;

        private IEventBus _signalBus;
        private IGameStats _gameStats;

        private void Awake()
        {
            _signalBus = new EventBus();
            _gameStats = new GameStats(_signalBus);

            _animalSpawner.Init(_signalBus, _animalSpawnerData);
            _heroCreator.Init(_signalBus);
            _inputReader.Init(_signalBus);
            _gameStatsView.Init(_gameStats);
        }

        private void Update()
        {
            _animalSpawner.Tick();
            _heroCreator.Tick();
        }

        private void OnDestroy()
        {
            _gameStats.Dispose();
        }
    }
}