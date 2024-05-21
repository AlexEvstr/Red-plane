using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    private float spawnIntervalMin = 1f;
    private float spawnIntervalMax = 5f;

    void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    IEnumerator SpawnCoins()
    {
        while (true)
        {
            SpawnCoin();

            yield return new WaitForSeconds(Random.Range(spawnIntervalMin, spawnIntervalMax));
        }
    }

    void SpawnCoin()
    {
        float x = 5f; 
        float y = Random.Range(-2f, 4f); 

        Instantiate(coinPrefab, new Vector3(x, y, 0), Quaternion.identity);
    }
}
