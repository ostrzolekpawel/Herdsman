using System.Collections.Generic;
using Herdsman.Animals;

namespace Herdsman
{
    public class Herd : IHerd
    {
        private readonly int _capacity;
        private readonly List<IAnimal> _animals;

        public Herd(IHerdData config)
        {
            _animals = new List<IAnimal>();
            _capacity = config.Capacity;    
        }

        public void Collect(IAnimal animal)
        {
            if (_animals.Count >= _capacity)
            {
                return;
            }

            _animals.Add(animal);
            animal.Follow();
        }

        public void Release(IAnimal animal)
        {
            if (_animals.Contains(animal))
            {
                _animals.Remove(animal);
            }
        }
    }
}