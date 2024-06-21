namespace Herdsman.Animals
{
    public class AnimalFollowPlayerSignal
    {
        public IAnimal Animal { get; }

        public AnimalFollowPlayerSignal(IAnimal animalView)
        {
            Animal = animalView;
        }
    }
}