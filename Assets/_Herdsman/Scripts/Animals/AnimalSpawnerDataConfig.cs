using UnityEngine;

namespace Herdsman.Animals
{
    [CreateAssetMenu(fileName = "AnimalSpawnerDataConfig", menuName = "Configs/AnimalSpawnerDataConfig")]
    public class AnimalSpawnerDataConfig : ScriptableObject, IAnimalSpawnerData
    {
        [SerializeField] private float _interval;
        public float Interval => _interval;
    }
}