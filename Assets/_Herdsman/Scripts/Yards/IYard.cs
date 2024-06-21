using Herdsman.Animals;

namespace Herdsman.Yards
{
    public interface IYard
    {
        void CollectAnimal(IAnimalView animalView);
    }
}