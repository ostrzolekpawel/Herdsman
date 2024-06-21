using UnityEngine;

namespace Herdsman.Player
{
    [CreateAssetMenu(fileName = "HeroDataConfig", menuName = "Configs/HeroDataConfig")]
    public class HeroDataConfig : ScriptableObject, IHeroData
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _collectRange;

        public float Speed => _speed;
        public float CollectRange => _collectRange;
    }
}