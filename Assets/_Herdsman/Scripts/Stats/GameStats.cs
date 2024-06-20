namespace Herdsman
{
    public class GameStats : IGameStats
    {
        public int Score { get; private set; }

        public void AddScore(int additionalScore)
        {
            Score += additionalScore;
        }

        public void UpdateScore(int newScore)
        {
            Score = newScore;
        }
    }
}