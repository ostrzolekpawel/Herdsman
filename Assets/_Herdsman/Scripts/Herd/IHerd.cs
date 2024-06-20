using Herdsman.Animals;

namespace Herdsman
{
    public interface IHerd
    {
        void Collect(IAnimal animal);
        void Release(IAnimal animal);
    }
}