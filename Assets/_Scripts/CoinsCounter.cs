using UnityEngine;
using TMPro;

public class CoinsCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsText;
    public static int Coins;

    private void Start()
    {
        Coins = PlayerPrefs.GetInt("coins", 0);
    }

    private void Update()
    {
        _coinsText.text = Coins.ToString();
    }
}