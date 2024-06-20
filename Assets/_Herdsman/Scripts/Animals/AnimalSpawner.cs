using Herdsman.Player;
using Herdsman.PositionProviders;
using OsirisGames.EventBroker;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Herdsman.Animals
{
    public class AnimalSpawner : MonoBehaviour, IAnimalSpawner
    {
        [SerializeField] private AnimalView _animalPrefab;
        [SerializeField] private AnimalDataConfig _animalConfig;
        [SerializeField] private Collider2D _fieldCollider;
        [SerializeField] private Collider2D _yardCollider;

        [SerializeField] private HeroView _heroView; // maybe user DI Container

        private const int SECTOR_SIZE = 1;

        private readonly Dictionary<IAnimal, AnimalView> _map = new Dictionary<IAnimal, AnimalView>();

        private ObjectPooler<AnimalView> _pool;
        private IPositionProvider _positionProvider;
        private IPositionProvider _heroPositionProvider;
        private IEventBus _signalBus;
        private float _timer;

        public float Interval { get; private set; }

        private void Awake()
        {
            _positionProvider = new RandomBoundSectorPositionProvider(SECTOR_SIZE, _fieldCollider.bounds, _yardCollider.bounds);
            _heroPositionProvider = new GameObjectPositionProvider(_heroView.transform);

            _pool = new ObjectPooler<AnimalView>(_animalPrefab, transform);
            _pool.OnCreate += CreateAnimalView;
            _pool.OnTake += TakeAnimalView;
            _pool.OnRelease += ReleaseAnimalView;
        }

        public void Init(IEventBus signalBus, IAnimalSpawnerData data)
        {
            _signalBus = signalBus;
            _signalBus.Subscribe<AnimalCollectInYardSignal>(ReleaseAnimalToPool);

            Interval = data.Interval;
        }

        private void TakeAnimalView(AnimalView animalView)
        {
            animalView.gameObject.SetActive(true); // reset position !! and state
        }

        private void ReleaseAnimalView(AnimalView animalView)
        {
            animalView.gameObject.SetActive(false);
        }

        private void CreateAnimalView(AnimalView animalView)
        {
            var animal = new AnimalBuilder(_positionProvider, _heroPositionProvider, _animalConfig)
                .WithStateMachine()
                .WithMovement(new MoveTowardsObjectMovement(animalView.transform, _animalConfig.Speed))
                .Build();

            animalView.Init(animal, _signalBus);

            _map[animal] = animalView;
        }

        public void Spawn()
        {
            var animalView = _pool.TakeFromPool();
            if (animalView != null)
            {
                // always create new animal?
                //var animal = new AnimalBuilder(_positionProvider, _heroPositionProvider, _animalConfig)
                //    .WithStateMachine()
                //    .WithMovement(new MoveTowardsObjectMovement(animalView.transform, _animalConfig.Speed))
                //    .Build();

                //animalView.Init(animal, _signalBus);

                //_map[animal] = animalView;
            }
        }

        public void Tick()
        {
            _timer += Time.deltaTime;

            if (_timer > Interval)
            {
                Spawn();
                _timer = 0;
            }
        }

        private void ReleaseAnimalToPool(AnimalCollectInYardSignal signal)
        {
            var animal = signal.Animal;
            var view = _map[animal];
            if (view != null)
            {
                _pool.ReleaseToPool(view);
                animal.Reset();
            }
        }

        private void OnDestroy()
        {
            _pool.OnCreate -= CreateAnimalView;
            _pool.OnTake -= TakeAnimalView;
            _pool.OnRelease -= ReleaseAnimalView;
            _signalBus.Unsubscribe<AnimalCollectInYardSignal>(ReleaseAnimalToPool);
        }
    }
}