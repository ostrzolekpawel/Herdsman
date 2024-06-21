using UnityEngine;

namespace Herdsman.Movement
{
    public class TeleportMovement : IMovement
    {
        public Vector2 Move(Vector2 targetPosition)
        {
            return targetPosition;
        }
    }
}