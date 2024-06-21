namespace Herdsman.Animals
{
    public class RandomIntervalGenerator : IIntervalGenerator
    {
        private readonly float _minInterval;
        private readonly float _maxInterval;

        public RandomIntervalGenerator(float minInterval, float maxInterval)
        {
            _minInterval = minInterval;
            _maxInterval = maxInterval;
        }

        public float GetNextInterval()
        {
            return UnityEngine.Random.Range(_minInterval, _maxInterval);
        }
    }
}