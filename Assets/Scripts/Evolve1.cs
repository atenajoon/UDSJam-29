using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolve1 : MonoBehaviour
{
    // public GameObject nextPrefab;
    public GameObject[] replacementPrefabs;
    int collisionCount = 0; // Counter to track collisions


   

    // void HandleCollision(GameObject nextPrefab, Collision2D collision)
    // {
    //     if (!nextPrefab)
    //     {
    //         Debug.Log("Final Evolution");
    //         return;
    //     }
    //     else
    //     { 
    //         Destroy(collision.gameObject);
    //         Destroy(gameObject);

    //         GameObject evolvePoint = GameObject.FindWithTag("EvolvePoint");
    //         Vector3 position = evolvePoint.transform.position;
    //         Quaternion rotation = evolvePoint.transform.rotation;

    //         GameObject newPrefab = Instantiate(nextPrefab, position, rotation);
    //      }
    // }
    // void EvolvePrefab(GameObject nextPrefab, Collision2D collision)
    // {
    //     // Destroy Both of the collided objects
    //     Destroy(collision.gameObject);
    //     // Destroy(gameObject);

    //     GameObject evolvePoint = GameObject.FindWithTag("EvolvePoint");
    //     Vector3 position = evolvePoint.transform.position;
    //     Quaternion rotation = evolvePoint.transform.rotation;

    //     GameObject newPrefab = Instantiate(nextPrefab, position, rotation);
        
    //     return;
    // }

}
