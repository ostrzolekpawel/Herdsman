using UnityEngine;

namespace Herdsman
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