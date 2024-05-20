using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    private float speed = 1.0f;
    private float extraSpeed = -3.0f;
    private bool movingLeft = true;
    private float changeDirectionTime;
    private float changeDirectionTimer;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetRandomDirectionTime();
    }

    void FixedUpdate()
    {
        float moveDirection = movingLeft ? -1f : 1f;

        if(GroundDetector.isGrounded)
        {
            transform.Translate(Vector2.right * moveDirection * speed * Time.deltaTime);
        }
        else
        {
            if (movingLeft)
            {
                transform.Translate(Vector2.left * moveDirection * extraSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * moveDirection * speed * Time.deltaTime);
            }
        }

        changeDirectionTimer += Time.deltaTime;

        if (changeDirectionTimer >= changeDirectionTime)
        {
            movingLeft = !movingLeft;
            spriteRenderer.flipX = !spriteRenderer.flipX;

            changeDirectionTimer = 0f;
            SetRandomDirectionTime();
        }

        if (transform.position.x < -3.5f)
        {
            Destroy(gameObject);
        }
    }

    void SetRandomDirectionTime()
    {
        changeDirectionTime = Random.Range(1f, 3f);
    }

    private void OnDestroy()
    {
        GameObject manager = GameObject.Find("Manager");
        if (manager != null)
        {
            AlienSpawner spawner = manager.GetComponent<AlienSpawner>();
            if (spawner != null)
            {
                spawner.OnAlienDestroyed();
            }
        }
    }
}