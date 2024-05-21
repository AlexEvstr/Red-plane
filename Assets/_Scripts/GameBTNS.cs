using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameBTNS : MonoBehaviour
{
    [SerializeField] private GameObject _shield;
    [SerializeField] private GameObject _magnet;

    [SerializeField] private TMP_Text _shieldCountText;
    [SerializeField] private TMP_Text _magnetCountText;

    private int _shielCount;
    private int _magnetCount;

    [SerializeField] private GameObject _player;

    private float magnetForce = 10f;
    private float magnetDuration = 10f;

    private void Start()
    {
        _shielCount = PlayerPrefs.GetInt("shieldCount", 1);
        _magnetCount = PlayerPrefs.GetInt("magnetCount", 1);
    }

    private void Update()
    {
        _shieldCountText.text = _shielCount.ToString();
        _magnetCountText.text = _magnetCount.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("gameScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("menuScene");
    }

    public void ShieldBtn()
    {
        if (_shielCount > 0)
        {
            _shielCount--;
            StartCoroutine(ActivateShield());
        }
    }

    private IEnumerator ActivateShield()
    {
        _player.GetComponent<PolygonCollider2D>().enabled = false;
        _shield.SetActive(true);

        yield return new WaitForSeconds(10);
        _shield.SetActive(false);
        _player.GetComponent<PolygonCollider2D>().enabled = true;
    }

    public void MagnetBtn()
    {
        if (_magnetCount > 0)
        {
            _magnetCount--;
            StartCoroutine(ActivateMagnet());
        }
    }

    private IEnumerator ActivateMagnet()
    {
        _magnet.SetActive(true);
        float elapsedTime = 0f;
        while (elapsedTime < magnetDuration)
        {
            elapsedTime += Time.deltaTime;

            GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
            foreach (GameObject coin in coins)
            {
                coin.GetComponent<CoinMovement>().enabled = false;
                Rigidbody2D rb = coin.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Vector2 direction = (_magnet.transform.position - coin.transform.position).normalized;
                    float step = magnetForce * Time.deltaTime;
                    coin.transform.position = Vector2.MoveTowards(coin.transform.position, _magnet.transform.position, step);
                }
            }

            yield return null;
        }
        _magnet.SetActive(false);
        GameObject[] coinss = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject coin in coinss)
        {
            coin.GetComponent<CoinMovement>().enabled = true;
        }
    }

}