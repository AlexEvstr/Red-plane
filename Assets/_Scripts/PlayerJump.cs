using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        GroundDetector.isGrounded = false;
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}