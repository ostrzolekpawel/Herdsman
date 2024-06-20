using Herdsman.PositionProviders;
using OsirisGames.EventBroker;
using System.Collections.Generic;
using UnityEngine;

namespace Herdsman.Animals
{
    public class AnimalSpawner : MonoBehaviour, IAnimalSpawner
    {
        private IEventBus _signalBus;

        [SerializeField] private AnimalView _animalPrefab;
        [SerializeField] private AnimalDataConfig _animalConfig;

        [SerializeField] private Bounds _fieldBounds;
        [SerializeField] private Bounds _yardBounds;

        private const int SECTOR_SIZE = 5;

        private ObjectPooler<AnimalView> _pool;
        private IPositionProvider _positionProvider;
        private IMovement _movement;

        private readonly Dictionary<IAnimal, AnimalView> _map = new Dictionary<IAnimal, AnimalView>();

        public float Interval { get; private set; }

        private void Awake()
        {
            _positionProvider = new RandomBoundSectorPositionProvider(SECTOR_SIZE, _fieldBounds, _yardBounds);
            _movement = new MoveTowardsObjectMovement();

            _pool = new ObjectPooler<AnimalView>(_animalPrefab, transform);
            _pool.OnTake += TakeAnimalView;
            _pool.OnRelease += ReleaseAnimalView;
        }

        public void Init(IEventBus signalBus, IAnimalSpawnerData data)
        {
            _signalBus = signalBus;
            _signalBus.Subscribe<CollectAnimalSignal>(ReleaseAnimalToPool);

            Interval = data.Interval;
        }

        private void TakeAnimalView(AnimalView animalView)
        {
            animalView.gameObject.SetActive(true);
        }

        private void ReleaseAnimalView(AnimalView animalView)
        {
            animalView.gameObject.SetActive(false);
        }

        public void Spawn()
        {
            var animalView = _pool.TakeFromPool();
            if (animalView != null)
            {
                var animal = new AnimalBuilder(_positionProvider, _movement, _animalConfig)
                    .WithStateMachine()
                    .Build();

                animalView.Init(animal, _signalBus);

                _map[animal] = animalView;
            }
        }

        public void Tick()
        {
        }

        private void ReleaseAnimalToPool(CollectAnimalSignal signal)
        {
            var view = _map[signal.Animal];
            if (view != null)
            {
                _pool.ReleaseToPool(view);
            }
        }

        private void OnDestroy()
        {
            _pool.OnTake -= TakeAnimalView;
            _pool.OnRelease -= ReleaseAnimalView;
            _signalBus.Unsubscribe<CollectAnimalSignal>(ReleaseAnimalToPool);
        }
    }
}