using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private int minDelay = 0;
    [SerializeField] private int maxDelay = 1;

    void Start()
    {
        StartCoroutine(SpawnFood());
    }

    IEnumerator SpawnFood()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            // Spawn food
            GameObject newFood = Instantiate(foodPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
            newFood.transform.SetParent(GameObject.FindGameObjectWithTag("GameArea").transform, false);
            // Destroy(newFood, 10f);
        }
    }
}
