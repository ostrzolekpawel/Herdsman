namespace Herdsman.Animals
{
    public class CollectAnimalSignal
    {
        public IAnimal Animal { get; }

        public CollectAnimalSignal(IAnimal animal)
        {
            Animal = animal;
        }
    }
}