using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    // [SerializeField] private Species speciesToSpawn;
    [SerializeField] private float spawnRegionWidth;
    public GameObject[] speciesPrefabs;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 3f;
    private float nextSpawnTime;
    private Dictionary<GameObject, int> speciesCount = new Dictionary<GameObject, int>();

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
        int randomIndex = Random.Range(0, speciesPrefabs.Length);
        GameObject selectedSpeciesPrefab = speciesPrefabs[randomIndex];
        
        GameObject _newSpecies = Instantiate(selectedSpeciesPrefab, GetRandomPosition(), Quaternion.identity);

        // Adjust falling speed based on the weight of the species
        SpeciesPrefab speciesScript = _newSpecies.GetComponent<SpeciesPrefab>();
        if (speciesScript != null)
        {
            float weight = speciesScript.speciesWeight;
            // Adjust falling speed based on weight (for example, adjust Rigidbody2D gravity scale)
            Rigidbody2D rb = _newSpecies.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Adjust gravity scale based on weight
                // You might need to adjust this value based on your game's physics settings
                rb.gravityScale = 1f + weight * 0.5f;
            }
        }

        if(!speciesCount.ContainsKey(selectedSpeciesPrefab))
        {
            speciesCount[selectedSpeciesPrefab] = 1;
        }
        else
        {
            speciesCount[selectedSpeciesPrefab]++ ;
        }
        // Debug.Log("Spawning " + selectedSpeciesPrefab.name + ": " + speciesCount[selectedSpeciesPrefab]);      
    }

    private Vector3 GetRandomPosition()
    {
        float randomXPosition = Random.Range(-spawnRegionWidth, spawnRegionWidth);
        return new Vector3(randomXPosition, transform.position.y, transform.position.z);
    }

}
