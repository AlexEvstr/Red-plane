using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    [SerializeField] private GameObject _offMusic;
    [SerializeField] private GameObject _onMusic;

    private void Start()
    {
        float music = PlayerPrefs.GetFloat("music", 1);
        if (music == 1)
        {
            TurnOnMusic();
        }
        else
        {
            TurnOffMusic();
        }
    }

    public void TurnOffMusic()
    {
        _onMusic.SetActive(false);
        _offMusic.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetFloat("music", 0);
    }

    public void TurnOnMusic()
    {
        _offMusic.SetActive(false);
        _onMusic.SetActive(true);
        AudioListener.volume = 1;
        PlayerPrefs.SetFloat("music", 1);
    }
}
