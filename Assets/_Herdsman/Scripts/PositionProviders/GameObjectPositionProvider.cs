using Herdsman.PositionProviders;
using UnityEngine;

namespace Herdsman.PositionProviders
{
    public class GameObjectPositionProvider : IPositionProvider
    {
        private readonly Transform _transform;

        public GameObjectPositionProvider(Transform transform)
        {
            _transform = transform;
        }

        public Vector2 GetPosition()
        {
            return _transform.position;
        }
    }
}