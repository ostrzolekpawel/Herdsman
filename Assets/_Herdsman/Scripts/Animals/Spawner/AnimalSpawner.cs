using Herdsman.Player;
using Herdsman.PositionProviders;
using OsirisGames.EventBroker;
using UnityEngine;

namespace Herdsman.Animals
{
    public class AnimalSpawner : MonoBehaviour, IAnimalSpawner
    {
        [SerializeField] private AnimalView _animalPrefab;
        [SerializeField] private AnimalDataConfig _animalConfig;
        [SerializeField] private Collider2D _fieldCollider;
        [SerializeField] private Collider2D _yardCollider;
        [SerializeField] private HeroView _heroView;

        private const int SECTOR_SIZE = 1;
        private IPositionProvider _positionProvider;
        private IPositionProvider _heroPositionProvider;
        private IEventBus _signalBus;
        private IAnimalPool _animalPool;
        private IAnimalFactory _animalFactory;
        private AnimalEventHandler _animalEventHandler;
        private IIntervalGenerator _intervalGenerator;
        private float _lastSpawned;
        private float _nextSpawnTime;
        private float _currentInterval;

        public void Init(IEventBus signalBus, IAnimalSpawnerData data)
        {
            _positionProvider = new RandomBoundSectorPositionProvider(SECTOR_SIZE, _fieldCollider.bounds, _yardCollider.bounds);
            _heroPositionProvider = new GameObjectPositionProvider(_heroView.transform);
            _signalBus = signalBus;

            _animalFactory = new AnimalFactory(_positionProvider, _heroPositionProvider, _animalConfig, _signalBus);
            _animalPool = new AnimalPool(_animalPrefab, transform, _animalFactory);
            _animalEventHandler = new AnimalEventHandler(_signalBus, _animalFactory, _animalPool);
            _intervalGenerator = new RandomIntervalGenerator(data.MinInterval, data.MaxInterval);

            _currentInterval = _intervalGenerator.GetNextInterval();

            Prespawn(data.PrespawnedAnimalCount);
        }

        public void Prespawn(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Spawn();
            }
        }

        public void Spawn()
        {
            var animalView = _animalPool.TakeFromPool();
            if (animalView != null)
            {
                // Additional logic if needed
            }
            _currentInterval = _intervalGenerator.GetNextInterval();
        }

        public void Tick()
        {
            if (Time.time > _nextSpawnTime)
            {
                Spawn();
                _lastSpawned = Time.time;
                _nextSpawnTime = _lastSpawned + _currentInterval;
            }
        }

        private void OnDestroy()
        {
            _animalPool.Dispose();
            _animalEventHandler.Dispose();
        }
    }
}