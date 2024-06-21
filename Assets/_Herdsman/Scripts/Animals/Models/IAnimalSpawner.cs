namespace Herdsman.Animals
{
    public interface IAnimalSpawner
    {
        void Spawn();
        void Prespawn(int count);
    }
}