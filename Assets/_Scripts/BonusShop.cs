using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BonusShop : MonoBehaviour
{
    private int coins;
    private int shieldCount;
    private int magnetCount;
    private int bonusCost = 10;

    [SerializeField] private TMP_Text coinText;
    [SerializeField] private TMP_Text shieldCountText;
    [SerializeField] private TMP_Text magnetCountText;
    [SerializeField] private TMP_Text shieldButtonText;
    [SerializeField] private TMP_Text magnetButtonText;

    [SerializeField] private Button buyShieldButton;
    [SerializeField] private Button buyMagnetButton;

    private void Start()
    {
        coins = PlayerPrefs.GetInt("coins", 0);
        shieldCount = PlayerPrefs.GetInt("shieldCount", 1);
        magnetCount = PlayerPrefs.GetInt("magnetCount", 1);
        UpdateUI();
        buyShieldButton.onClick.AddListener(BuyShield);
        buyMagnetButton.onClick.AddListener(BuyMagnet);
    }

    private void UpdateUI()
    {
        coinText.text = coins.ToString();
        shieldCountText.text = shieldCount.ToString();
        magnetCountText.text = magnetCount.ToString();
        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefs.SetInt("shieldCount", shieldCount);
        PlayerPrefs.SetInt("magnetCount", magnetCount);
        shieldButtonText.text = "+1 Shield \n" + bonusCost;
        magnetButtonText.text = "+1 Magnet \n" + bonusCost;
    }

    private void BuyShield()
    {
        if (coins >= bonusCost)
        {
            coins -= bonusCost;
            shieldCount += 1;
            UpdateUI();
        }
    }

    private void BuyMagnet()
    {
        if (coins >= bonusCost)
        {
            coins -= bonusCost;
            magnetCount += 1;
            UpdateUI();
        }
    }
}
