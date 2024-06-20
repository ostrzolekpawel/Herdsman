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

        [SerializeField] private AnimalSpawnerDataConfig _animalSpawnerData;
        [SerializeField] private HerdDataConfig _herdDataConfig;

        private IEventBus _signalBuys;

        private void Awake()
        {
            _signalBuys = new EventBus();
            var herd = new Herd(_herdDataConfig);

            _animalSpawner.Init(_signalBuys, _animalSpawnerData);
            _heroCreator.Init(_signalBuys, herd);
            _inputReader.Init(_signalBuys);
        }

        private void Update()
        {
            _animalSpawner.Tick();
            _heroCreator.Tick();
        }
    }
}