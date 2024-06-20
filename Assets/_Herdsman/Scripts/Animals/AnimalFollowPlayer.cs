namespace Herdsman.Animals
{
    public class AnimalFollowPlayer
    {
        public IAnimal Animal { get; }

        public AnimalFollowPlayer(IAnimal animalView)
        {
            Animal = animalView;
        }
    }
}