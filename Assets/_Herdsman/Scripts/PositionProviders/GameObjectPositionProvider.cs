using System;
using UnityEngine;

namespace Herdsman.PositionProviders
{
    public class GameObjectPositionProvider : IPositionProvider
    {
        private readonly Transform _transform;

        public GameObjectPositionProvider(Transform transform)
        {
            if (!transform)
            {
                throw new ArgumentNullException(nameof(transform), "Transform cannot be null.");
            }
            _transform = transform;
        }
    
        public Vector2 GetPosition()
        {
            return _transform.position;
        }
    }
}