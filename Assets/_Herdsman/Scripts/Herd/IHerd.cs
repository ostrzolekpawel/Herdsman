using Herdsman.Animals;
using System;

namespace Herdsman
{
    public interface IHerd : IDisposable
    {
        void Collect(IAnimal animal);
        void Release(IAnimal animal);
    }
}