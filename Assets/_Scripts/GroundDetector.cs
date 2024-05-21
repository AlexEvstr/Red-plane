using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _camera;

    [SerializeField] private GameObject _groundHit;
    [SerializeField] private GameAudioManager _gameAudioManager;
    public static bool isGrounded;

    // Позиции камеры
    private Vector3 groundedPosition = new Vector3(1.25f, 0, -10);
    private Vector3 airPosition = new Vector3(0, 0, -10);

    // Скорость интерполяции
    private float smoothSpeed = 0.035f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isGrounded = true;

            _gameAudioManager.GroundHitSound();
            GameObject groundHit = Instantiate(_groundHit);
            groundHit.transform.position = new Vector2(collision.gameObject.transform.position.x,
                                                        collision.gameObject.transform.position.y - 0.3f);
            Destroy(groundHit, 0.5f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        // Выбор целевой позиции камеры
        Vector3 targetPosition = isGrounded ? groundedPosition : airPosition;

        // Плавное перемещение камеры
        _camera.position = Vector3.Lerp(_camera.position, targetPosition, smoothSpeed);
    }
}