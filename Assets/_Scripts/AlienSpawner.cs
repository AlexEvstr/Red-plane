using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    public GameObject alienPrefab; // Префаб объекта Alien
    private int maxAliens = 3; // Максимальное количество объектов Alien
    private int currentAlienCount = 0;

    void Start()
    {
        // Спавн начальных объектов Alien
        for (int i = 0; i < maxAliens; i++)
        {
            SpawnAlien();
        }
    }

    void Update()
    {
        // Если текущих объектов Alien меньше максимального количества, спавним новый
        if (currentAlienCount < maxAliens)
        {
            SpawnAlien();
        }
    }

    void SpawnAlien()
    {
        float x = Random.Range(3f, 10f); // Рандомное значение по оси x
        float y = -2.7f; // Значение по оси y

        GameObject newAlien = Instantiate(alienPrefab, new Vector3(x, y, 0), Quaternion.identity);
        currentAlienCount++;
    }

    // Метод для уменьшения счётчика текущих объектов Alien
    public void OnAlienDestroyed()
    {
        currentAlienCount--;
    }
}
