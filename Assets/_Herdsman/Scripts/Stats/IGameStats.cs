using System;

namespace Herdsman
{
    public interface IGameStats : IDisposable
    {
        NotifiableValue<int> Score { get; }
        void AddScore(int additionalScore);
        void UpdateScore(int newScore);
    }
}