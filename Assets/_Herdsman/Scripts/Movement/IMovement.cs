using UnityEngine;

namespace Herdsman.Movement
{
    public interface IMovement
    {
        Vector2 Move(Vector2 targetPosition);
    }
}