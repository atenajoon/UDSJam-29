using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    // [SerializeField] private Species speciesToSpawn;
    [SerializeField] private float spawnRegionWidth;
    public GameObject speciesPrefab;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 3f;

    private float nextSpawnTime;

    void Start()
    {
        // Calculate the time for the first spawn
        nextSpawnTime = Time.time + Random.Range(minSpawnDelay, maxSpawnDelay);
    }

    void Update()
    {
        // Check if it's time to spawn a new object
        if (Time.time >= nextSpawnTime)
        {
            SpawnSpecies();
            // Calculate the time for the next spawn
            nextSpawnTime = Time.time + Random.Range(minSpawnDelay, maxSpawnDelay);
        }
    }

    void SpawnSpecies()
    {
        Instantiate(speciesPrefab, GetRandomPosition(), Quaternion.identity);
        Debug.Log("Spawning");
    }

    private Vector3 GetRandomPosition()
    {
        float randomXPosition = Random.Range(-spawnRegionWidth, spawnRegionWidth);
        return new Vector3(randomXPosition, transform.position.y, transform.position.z);
    }

}
