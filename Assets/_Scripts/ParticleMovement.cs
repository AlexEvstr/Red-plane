using UnityEngine;

public class ParticleMovement : MonoBehaviour
{
    private float _speed = 2.0f;

    private void FixedUpdate()
    {
        if (!GroundDetector.isGrounded)
        {
            transform.Translate(Vector2.left * Time.deltaTime * _speed);
        }
        if (transform.position.x < -13)
        {
            transform.position = new Vector2(23, 0);
        }
    }
}