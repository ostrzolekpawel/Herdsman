using UnityEngine;

namespace Herdsman.Animals
{
    [CreateAssetMenu(fileName = "AnimalDataConfig", menuName = "Configs/AnimalDataConfig")]
    public class AnimalDataConfig : ScriptableObject, IAnimalData
    {
        [SerializeField] private int _points;
        [SerializeField] private float _speed;

        public int Points => _points;

        public float Speed => _speed;
    }
}