using System;

namespace Herdsman.Animals
{
    public interface IAnimalPool : IDisposable
    {
        IAnimalView TakeFromPool();
        void ReleaseToPool(IAnimalView animalView);
    }
}