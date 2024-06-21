using Herdsman.Animals;
using UnityEngine;

namespace Herdsman.Yards
{
    public class Yard : MonoBehaviour, IYard
    {
        public void CollectAnimal(IAnimalView animalView)
        {
            animalView?.Collect();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<IAnimalView>() is IAnimalView animal)
            {
                CollectAnimal(animal);
            }
        }
    }
}