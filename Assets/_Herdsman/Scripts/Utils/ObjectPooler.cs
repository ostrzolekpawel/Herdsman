using System.Collections.Generic;
using System;
using UnityEngine;

namespace Herdsman
{
    public class ObjectPooler<T> where T : UnityEngine.Object
    {
        private readonly Queue<T> _available = new Queue<T>();
        private readonly Transform _parent;
        private readonly T _prefab;

        public event Action<T> OnCreate;
        public event Action<T> OnTake;
        public event Action<T> OnRelease;

        public ObjectPooler(T prefab, Transform parent = null)
        {
            _parent = parent;
            _prefab = prefab;
        }

        public T TakeFromPool()
        {
            T pooled = null;

            if (_available.Count != 0)
            {
                pooled = _available.Dequeue();
                OnTake?.Invoke(pooled);
            }
            else if (_prefab != null)
            {
                pooled = _parent != null ? UnityEngine.Object.Instantiate(_prefab, _parent) :
                                            UnityEngine.Object.Instantiate(_prefab);
                OnCreate?.Invoke(pooled);
                OnTake?.Invoke(pooled);
            }

            return pooled;
        }

        public void ReleaseToPool(T @object)
        {
            _available.Enqueue(@object);
            OnRelease?.Invoke(@object);
        }
    }

    public class ObjectPooler<T, U> where T : UnityEngine.Object, U
    {
        private readonly Queue<U> _available = new Queue<U>();
        private readonly Transform _parent;
        private readonly T _prefab;

        public event Action<U> OnCreate;
        public event Action<U> OnTake;
        public event Action<U> OnRelease;

        public ObjectPooler(T prefab, Transform parent = null)
        {
            _parent = parent;
            _prefab = prefab;
        }

        public U TakeFromPool()
        {
            U pooled = default;

            if (_available.Count != 0)
            {
                pooled = _available.Dequeue();
                OnTake?.Invoke(pooled);
            }
            else if (_prefab != null)
            {
                pooled = _parent != null ? UnityEngine.Object.Instantiate(_prefab, _parent) :
                                            UnityEngine.Object.Instantiate(_prefab) ;
                OnCreate?.Invoke(pooled);
                OnTake?.Invoke(pooled);
            }

            return pooled;
        }

        public void ReleaseToPool(U @object)
        {
            _available.Enqueue(@object);
            OnRelease?.Invoke(@object);
        }
    }
}