using UnityEngine;

namespace Herdsman.Player
{
    public class MoveHeroToTargetSignal
    {
        public Vector3 TargerPosition { get; }

        public MoveHeroToTargetSignal(Vector3 targerPosition)
        {
            TargerPosition = targerPosition;
        }
    }
}