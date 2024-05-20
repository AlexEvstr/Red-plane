using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    private float _speed = 2f;
    private Vector2 _zeroPosition;
    private float _middleOfBackground;

    private void Start()
    {
        _zeroPosition = transform.position;
        _middleOfBackground = GetComponent<BoxCollider2D>().size.x / 2;
    }

    private void FixedUpdate()
    {
        if (!GroundDetector.isGrounded)
        {
            transform.Translate(Vector2.left * Time.deltaTime * _speed);
            if (transform.position.x < (_zeroPosition.x - _middleOfBackground))
                transform.position = _zeroPosition;
        }
    }
}
