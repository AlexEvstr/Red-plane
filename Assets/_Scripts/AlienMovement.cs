using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    private float speed = 1.0f;
    private bool movingLeft = true;
    private float changeDirectionTime;
    private float changeDirectionTimer;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Получаем компонент SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Устанавливаем начальное время для смены направления
        SetRandomDirectionTime();
    }

    void Update()
    {
        // Двигаем бота влево или вправо в зависимости от значения movingLeft
        float moveDirection = movingLeft ? -1f : 1f;
        transform.Translate(Vector2.right * moveDirection * speed * Time.deltaTime);

        // Увеличиваем таймер
        changeDirectionTimer += Time.deltaTime;

        // Проверяем, нужно ли менять направление
        if (changeDirectionTimer >= changeDirectionTime)
        {
            // Меняем направление движения
            movingLeft = !movingLeft;

            // Обновляем flipX для SpriteRenderer
            spriteRenderer.flipX = !spriteRenderer.flipX;

            // Сбрасываем таймер и устанавливаем новое случайное время для смены направления
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
}
