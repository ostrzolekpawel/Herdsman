using TMPro;
using UnityEngine;

namespace Herdsman
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _score;

        // inject GameStats to get score?

        private void Start()
        {
            
        }

        private void UpdateScore(int currentScore)
        {
            _score.text = currentScore.ToString();
        }

        private void OnDestroy()
        {
            
        }
    }
}