namespace Herdsman.Animals
{
    public interface IAnimalSpawnerData
    {
        float MinInterval { get; }
        float MaxInterval { get; }
        int PrespawnedAnimalCount { get; }
    }
}