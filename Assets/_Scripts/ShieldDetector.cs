using System.Collections;
using UnityEngine;

public class ShieldDetector : MonoBehaviour
{
    [SerializeField] GameAudioManager gameAudioManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(RotateOverTime(collision.gameObject,180f, 1f));
        }
    }

    private IEnumerator RotateOverTime(GameObject enemy, float angle, float duration)
    {
        
        float startRotation = enemy.transform.eulerAngles.z;
        float endRotation = startRotation + angle;
        float t = 0f;
        enemy.GetComponent<Collider2D>().enabled = false;
        enemy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        gameAudioManager.ShieldCollisionSound();

        AlienSpawner.currentAlienCount--;
        while (t < duration || enemy != null)
        {
            t += Time.deltaTime;
            float zRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360f;

            enemy.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zRotation);
            yield return null;
        }
    }
}