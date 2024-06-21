using UnityEngine;

namespace Herdsman.Animals
{
    [CreateAssetMenu(fileName = "AnimalSpawnerDataConfig", menuName = "Configs/AnimalSpawnerDataConfig")]
    public class AnimalSpawnerDataConfig : ScriptableObject, IAnimalSpawnerData
    {
        [SerializeField] private float _minInterval;
        [SerializeField] private float _maxInterval;
        [SerializeField] private int _prespawnedAnimalCount;

        public float MinInterval => _minInterval;
        public float MaxInterval => _maxInterval;
        public int PrespawnedAnimalCount => _prespawnedAnimalCount;
    }
}