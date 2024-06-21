namespace Herdsman.Animals
{
    public interface IAnimalFactory
    {
        void CreateAnimal(IAnimalView animalView);
        void ResetAnimal(IAnimal animal);
        IAnimalView GetAnimalView(IAnimal animal);
    }
}