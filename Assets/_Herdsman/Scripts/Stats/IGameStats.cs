namespace Herdsman
{
    public interface IGameStats
    {
        int Score { get; }
        void AddScore(int additionalScore);
        void UpdateScore(int newScore);
    }
}