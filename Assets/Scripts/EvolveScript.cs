using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolveScript : MonoBehaviour
{
    private int _bearCount = 0;
    private int _fishCount = 0;
    private int _rabbitCount = 0;

    public GameObject[] bearPrefabs;
    public GameObject[] fishPrefabs;
    public GameObject[] rabbitPrefabs;
    private bool shouldDestroyBearEgg = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 position = other.transform.position;
        Quaternion rotation = other.transform.rotation;
        string speciesTag = other.gameObject.tag;

        switch (speciesTag)
        {
            case "BearEgg":
                if(_bearCount == 1)
                    Destroy(other.gameObject);

                EvolveBear(position, rotation);
                break;

            case "FishEgg":
                if(_fishCount == 1)
                    Destroy(other.gameObject);

                EvolveFish(position, rotation);
                break;

            case "RabbitEgg":
                if(_rabbitCount == 1)
                    Destroy(other.gameObject);
    
                EvolveRabbit(position, rotation);
                break;
            default:
                break;                                                              
        }
    }
    void EvolveBear(Vector3 position, Quaternion rotation)
    {
        GameObject newPrefab = null;
        switch (_bearCount)
        {
            case 1:
                newPrefab = Instantiate(bearPrefabs[0], position, rotation);
                break;
            case 2:
                newPrefab = Instantiate(bearPrefabs[1], position, rotation);
                break;
            case 3:
                newPrefab = Instantiate(bearPrefabs[2], position, rotation);
                break;
            default:
                break;
        }

        _bearCount++;
        Debug.Log("Bear Evolved: " + _bearCount);        
    }
        void EvolveFish(Vector3 position, Quaternion rotation)
    {
        GameObject newPrefab = null;
        switch (_fishCount)
        {
            case 1:
                newPrefab = Instantiate(fishPrefabs[0], position, rotation);
                break;
            case 2:
                newPrefab = Instantiate(fishPrefabs[1], position, rotation);
                break;
            case 3:
                newPrefab = Instantiate(fishPrefabs[2], position, rotation);
                break;
            default:
                break;
        }

        _fishCount++;
        Debug.Log("Fish Evolved: " + _fishCount);
    }
    void EvolveRabbit(Vector3 position, Quaternion rotation)
    {
        GameObject newPrefab = null;
        switch (_rabbitCount)
        {
            case 1:
                newPrefab = Instantiate(rabbitPrefabs[0], position, rotation);
                break;
            case 2:
                newPrefab = Instantiate(rabbitPrefabs[1], position, rotation);
                break;
            case 3:
                newPrefab = Instantiate(rabbitPrefabs[2], position, rotation);
                break;
            default:
                break;
        }

        _rabbitCount++;
        Debug.Log("Rabbit Evolved: " + _rabbitCount);
    }
}
