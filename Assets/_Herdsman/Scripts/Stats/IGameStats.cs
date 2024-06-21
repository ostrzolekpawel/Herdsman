using System;

namespace Herdsman.Stats
{
    public interface IGameStats : IDisposable
    {
        NotifiableValue<int> Score { get; }
        void AddScore(int additionalScore);
        void UpdateScore(int newScore);
    }
}