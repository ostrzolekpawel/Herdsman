namespace Herdsman.Animals
{
    public class AnimalCollectInYardSignal
    {
        public IAnimal Animal { get; }

        public AnimalCollectInYardSignal(IAnimal animal)
        {
            Animal = animal;
        }
    }
}