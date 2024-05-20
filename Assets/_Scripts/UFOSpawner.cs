using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawner : MonoBehaviour
{
    public GameObject[] ufoPrefabs; // Массив префабов UFO
    public float spawnIntervalMin = 2f; // Минимальное время между спавном
    public float spawnIntervalMax = 6f; // Максимальное время между спавном

    void Start()
    {
        // Запускаем корутину для спавна объектов UFO
        StartCoroutine(SpawnUFOs());
    }

    IEnumerator SpawnUFOs()
    {
        while (true)
        {
            SpawnUFO();
            // Ждём случайное время перед следующим спавном
            yield return new WaitForSeconds(Random.Range(spawnIntervalMin, spawnIntervalMax));
        }
    }

    void SpawnUFO()
    {
        float x = Random.value > 0.5f ? -4f : 4f; // Координата x = -4 или 4
        float y = Random.Range(-1f, 4f); // Координата y в диапазоне от -1 до 4

        // Выбираем случайный префаб для спавна из массива
        int randomIndex = Random.Range(0, ufoPrefabs.Length);
        GameObject selectedPrefab = ufoPrefabs[randomIndex];

        Instantiate(selectedPrefab, new Vector3(x, y, 0), Quaternion.identity);
    }
}
