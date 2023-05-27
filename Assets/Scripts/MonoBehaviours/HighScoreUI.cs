using TMPro;
using UnityEngine;

namespace Scripts.MonoBehaviours
{
    public class HighScoreUI : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _scoreText;

        [SerializeField]
        private GameDataService _gameDataService;

        private void Awake()
        {
            _gameDataService.Init();
            var score = _gameDataService.LoadFromJSON().HighScore;
            _scoreText.text = $"High score: {score.ToString()}";
        }
    }
}
