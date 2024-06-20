using UnityEngine;

namespace Herdsman
{
    public interface IMovement
    {
        Vector2 Move(Vector2 targetPosition);
    }
}