using UnityEngine;

namespace Herdsman.Herds
{
    [CreateAssetMenu(fileName = "HerdDataConfig", menuName = "Configs/HerdDataConfig")]
    public class HerdDataConfig : ScriptableObject, IHerdData
    {
        [SerializeField] private int _capacity;
        public int Capacity => _capacity;
    }
}