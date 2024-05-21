using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _bestText;

    private void Start()
    {
        _bestText.text = "BEST: " + PlayerPrefs.GetFloat("bestScore", 0).ToString("F1");
        Time.timeScale = 1;
    }

    public void PlayBtn()
    {
        SceneManager.LoadScene("gameScene");
    }
}
