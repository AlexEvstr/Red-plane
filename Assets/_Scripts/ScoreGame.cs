using UnityEngine;
using TMPro;

public class ScoreGame : MonoBehaviour
{
    private float _score = 0f;
    private float _bestScore;

    public TMP_Text _scoreText;

    void Update()
    {
        if (!GroundDetector.isGrounded)
        {
            _score += Time.deltaTime;

            string displayedScore = _score.ToString("F1");

            if (_scoreText != null)
            {
                _scoreText.text = $"{displayedScore}";
            }
        }
        if (_bestScore < _score)
        {
            _bestScore = _score;
            PlayerPrefs.SetFloat("bestScore", _bestScore);
        }
    }
}