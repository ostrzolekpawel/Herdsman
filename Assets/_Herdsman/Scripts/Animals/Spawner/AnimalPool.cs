﻿using Herdsman.Utils;
using System;
using UnityEngine;

namespace Herdsman.Animals
{
    public class AnimalPool : IAnimalPool
    {
        private readonly ObjectPooler<AnimalView, IAnimalView> _pool;
        private readonly IAnimalFactory _animalFactory;

        public AnimalPool(AnimalView prefab, Transform parent, IAnimalFactory animalFactory)
        {
            if (prefab == null)
            {
                throw new ArgumentNullException(nameof(prefab), "Prefab used for object pooling cannot be null.");
            }

            _animalFactory = animalFactory ?? throw new ArgumentNullException(nameof(animalFactory), "AnimalFactory cannot be null.");
            _pool = new ObjectPooler<AnimalView, IAnimalView>(prefab, parent);

            _pool.OnCreate += CreateAnimal;
            _pool.OnTake += TakeAnimal;
            _pool.OnRelease += ReleaseAnimal;
        }

        private void CreateAnimal(IAnimalView animalView)
        {
            _animalFactory.CreateAnimal(animalView);
        }

        private void TakeAnimal(IAnimalView animalView)
        {
            animalView.Activate();
        }

        private void ReleaseAnimal(IAnimalView animalView)
        {
            animalView.Deactivate();
        }

        public IAnimalView TakeFromPool()
        {
            return _pool.TakeFromPool();
        }

        public void ReleaseToPool(IAnimalView animalView)
        {
            _pool.ReleaseToPool(animalView);
        }

        public void Dispose()
        {
            _pool.OnCreate -= CreateAnimal;
            _pool.OnTake -= TakeAnimal;
            _pool.OnRelease -= ReleaseAnimal;
        }
    }
}