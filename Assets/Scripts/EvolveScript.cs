using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolveScript : MonoBehaviour
{
    private int BearCount = 0;
    private int FishCount = 0;
    private int RabbitCount = 0;

    public GameObject[] bearPrefabs;
    public GameObject[] fishPrefabs;
    public GameObject[] rabbitPrefabs;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("box-hit" + other.gameObject.tag);
        Vector3 position = other.transform.position;
        Quaternion rotation = other.transform.rotation;
        string speciesTag = other.gameObject.tag;

        switch (speciesTag)
        {
            case "Bear":
                Destroy(other.gameObject);
                EvolveBear(position, rotation);
                break;
            case "Fish":
                Destroy(other.gameObject);
                EvolveFish(position, rotation);
                break;
            case "Rabbit":
                Destroy(other.gameObject);
                EvolveRabbit(position, rotation);
                break;
            default:
                break;                                                              
        }
    }
    void EvolveBear(Vector3 position, Quaternion rotation)
    {
        GameObject newPrefab = Instantiate(bearPrefabs[BearCount], position, rotation);
        BearCount++;
        Debug.Log("Bear Evolved: " + BearCount);
    }
        void EvolveFish(Vector3 position, Quaternion rotation)
    {
        GameObject newPrefab = Instantiate(fishPrefabs[FishCount], position, rotation);
        FishCount++;
        Debug.Log("Fish Evolved: " + FishCount);
    }
    void EvolveRabbit(Vector3 position, Quaternion rotation)
    {
        GameObject newPrefab = Instantiate(rabbitPrefabs[RabbitCount], position, rotation);
        RabbitCount++;
        Debug.Log("Rabbit Evolved: " + RabbitCount);
    }
}
