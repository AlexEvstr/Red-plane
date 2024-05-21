using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreGame : MonoBehaviour
{
    private float _score = 0f;

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
    }
}