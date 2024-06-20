using UnityEngine;

namespace Herdsman
{
    public class MoveTowardsObjectMovement : IMovement
    {
        private readonly float _speed;
        private readonly Transform _transform;

        public MoveTowardsObjectMovement(Transform transform, float speed)
        {
            _speed = speed;
            _transform = transform;
        }

        public Vector2 Move(Vector2 targetPosition)
        {
            return Vector2.MoveTowards(_transform.position, targetPosition, _speed * Time.deltaTime);
        }
    }

    public class TeleportMovement : IMovement
    {
        public Vector2 Move(Vector2 targetPosition)
        {
            return targetPosition;
        }
    }
}