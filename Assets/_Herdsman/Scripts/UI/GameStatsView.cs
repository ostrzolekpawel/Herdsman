using Herdsman.Stats;
using System;
using TMPro;
using UnityEngine;

namespace Herdsman.UI
{
    public class GameStatsView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private string _scoreFormat;

        private IGameStats _gameStats;

        public void Init(IGameStats gameStats)
        {
            _gameStats = gameStats ?? throw new ArgumentNullException(nameof(gameStats), "GameStats cannot be null.");
            _gameStats.Score.OnChange += UpdateScore;

            UpdateScore(0);
        }

        private void UpdateScore(int currentScore)
        {
            _score.text = string.Format(_scoreFormat, currentScore);
        }

        private void OnDestroy()
        {
            _gameStats.Score.OnChange -= UpdateScore;
            _gameStats.Dispose();
        }
    }
}