using System;
using UnityEngine;

namespace Herdsman.Movement
{
    public class MoveTowardsObjectMovement : IMovement
    {
        private readonly float _speed;
        private readonly Transform _transform;

        public MoveTowardsObjectMovement(Transform transform, float speed)
        {
            _speed = speed;
            if (!transform)
            {
                 throw new ArgumentNullException(nameof(transform), "Transform cannot be null.");
            }
            _transform = transform;
        }

        public Vector2 Move(Vector2 targetPosition)
        {
            return Vector2.MoveTowards(_transform.position, targetPosition, _speed * Time.deltaTime);
        }
    }
}