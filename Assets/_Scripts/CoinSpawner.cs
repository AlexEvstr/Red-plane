using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Префаб объекта монеты
    private float spawnIntervalMin = 1f; // Минимальное время между спавном
    private float spawnIntervalMax = 5f; // Максимальное время между спавном

    void Start()
    {
        // Запускаем корутину для спавна объектов монет
        StartCoroutine(SpawnCoins());
    }

    IEnumerator SpawnCoins()
    {
        while (true)
        {
            SpawnCoin();
            // Ждём случайное время перед следующим спавном
            yield return new WaitForSeconds(Random.Range(spawnIntervalMin, spawnIntervalMax));
        }
    }

    void SpawnCoin()
    {
        float x = 5f; // Координата x = 5
        float y = Random.Range(-2f, 4f); // Координата y в диапазоне от -2 до 4

        Instantiate(coinPrefab, new Vector3(x, y, 0), Quaternion.identity);
    }
}
