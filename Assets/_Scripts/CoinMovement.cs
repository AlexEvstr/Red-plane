using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    private float _speed = 0.1f;

    private void FixedUpdate()
    {
        if (GroundDetector.isGrounded)
        {
            transform.Translate(Vector2.left * Time.deltaTime * (_speed + 1));
        }
        else
        {
            transform.Translate(Vector2.left * Time.deltaTime * (_speed+3));
        }
    }
}
