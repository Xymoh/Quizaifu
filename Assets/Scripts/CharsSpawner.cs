using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject charPrefab;
    [SerializeField] private GameObject spawnPoint;

    [Header("Delay for char spawning")]
    [SerializeField] private float minDelay = 2f;
    [SerializeField] private float maxDelay = 4f;

    void Start()
    {
        StartCoroutine(SpawnChar());
    }

    IEnumerator SpawnChar()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            // Spawn words
            GameObject newChar = Instantiate(charPrefab, spawnPoint.transform.position, Quaternion.identity) as GameObject;
            newChar.transform.SetParent(GameObject.FindGameObjectWithTag("GameArea").transform, false);
        }
    }
}
