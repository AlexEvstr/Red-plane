using System.Collections;
using UnityEngine;

public class PlaneCollisionDetector : MonoBehaviour
{
    private float upwardForce = 3f;
    private float rightwardForce = 10f;
    public float rotationDuration = 1f;

    private Rigidbody2D rb;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private GameObject _jumpButton;
    [SerializeField] private ShakingCamera _shakingCamera;

    [SerializeField] private GameObject _gameOverScreen;

    [SerializeField] private GameAudioManager _gameAudioManager;
    [SerializeField] private GameObject _coinColletEffect;
    [SerializeField] private GameObject _hitCollisionEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.GetComponent<PolygonCollider2D>().enabled == true)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                _jumpButton.SetActive(false);

                GameObject hitCollision = Instantiate(_hitCollisionEffect);
                hitCollision.transform.position = new Vector2((collision.transform.position.x + transform.position.x)/2,
                                                              (collision.transform.position.y + transform.position.y)/2);
                Destroy(hitCollision, 1f);

                _gameAudioManager.DestroySound();

                gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                Vector2 force = new Vector2(rightwardForce, upwardForce);
                rb.AddForce(force, ForceMode2D.Impulse);
                _spriteRenderer.color = Color.red;
                _shakingCamera.StartShake();
                StartCoroutine(RotateOverTime(180f, rotationDuration));

                GroundDetector.isGrounded = true;

            }
        }
    }

    private IEnumerator RotateOverTime(float angle, float duration)
    {
        float startRotation = transform.eulerAngles.z;
        float endRotation = startRotation + angle;
        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float zRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zRotation);
            yield return null;
        }

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, endRotation % 360f);

        yield return new WaitForSeconds(1);
        _gameOverScreen.SetActive(true);
        _gameAudioManager.GameoverSound();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            GameObject coinEffect = Instantiate(_coinColletEffect);
            coinEffect.transform.position = new Vector2((collision.transform.position.x + transform.position.x)/2,
                                                        (collision.transform.position.y + transform.position.y) / 2);
            Destroy(coinEffect, 1f);
            Destroy(collision.gameObject);
            _gameAudioManager.CoinSound();
            CoinsCounter.Coins++;
            PlayerPrefs.SetInt("coins", CoinsCounter.Coins);
        }
    }
}