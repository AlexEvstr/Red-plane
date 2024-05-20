using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UfoMovement : MonoBehaviour
{
    private float _speed = 0.5f;
    private float _extraSpeed = 2.5f;

    private void Start()
    {
        if (transform.position.x < 0)
        {
            _speed = -_speed;
            _extraSpeed = -_extraSpeed;
        }
    }

    private void FixedUpdate()
    {
        if (_speed < 0)
        {
            if (GroundDetector.isGrounded)
            {
                transform.Translate(Vector2.left * _extraSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * _speed * Time.deltaTime);
            }
        }
        else
        {
            if (GroundDetector.isGrounded)
            {
                transform.Translate(Vector2.left * _speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * _extraSpeed * Time.deltaTime);
            }
        }
    }
}
