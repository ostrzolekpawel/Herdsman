using UnityEngine;

namespace Herdsman.PositionProviders
{
    public interface IPositionProvider
    {
        Vector2 GetPosition();
    }
}