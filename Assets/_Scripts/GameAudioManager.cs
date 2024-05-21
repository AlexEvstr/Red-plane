using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private AudioClip _bonusSound;
    [SerializeField] private AudioClip _coinSound;
    [SerializeField] private AudioClip _destroySound;
    [SerializeField] private AudioClip _gameoverSound;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _shieldCollisionSound;
    [SerializeField] private AudioClip _groundHitSound;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void ClickSound()
    {
        _audioSource.PlayOneShot(_clickSound);
    }

    public void BonusSound()
    {
        _audioSource.PlayOneShot(_bonusSound);
    }

    public void CoinSound()
    {
        _audioSource.PlayOneShot(_coinSound);
    }

    public void DestroySound()
    {
        _audioSource.PlayOneShot(_destroySound);
    }

    public void GameoverSound()
    {
        _audioSource.PlayOneShot(_gameoverSound);
    }

    public void JumpSound()
    {
        _audioSource.PlayOneShot(_jumpSound);
    }

    public void ShieldCollisionSound()
    {
        _audioSource.PlayOneShot(_shieldCollisionSound);
    }

    public void GroundHitSound()
    {
        _audioSource.PlayOneShot(_groundHitSound);
    }
}