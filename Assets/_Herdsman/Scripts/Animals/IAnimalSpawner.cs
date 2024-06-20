namespace Herdsman.Animals
{
    public interface IAnimalSpawner
    {
        float Interval { get; }
        void Spawn();
    }
}