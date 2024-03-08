using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeciesPrefab : MonoBehaviour
{
    public float speciesWeight;
    public GameObject[] bearPrefabs;
    public GameObject[] fishPrefabs;
    public GameObject[] rabbitPrefabs;
    int bearCollisionCount = 0; 
    int fishCollisionCount = 0; 
    int rabbitCollisionCount = 0; 

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        else 
        {
            string collidedTag = collision.gameObject.tag;

            //  if the 2 collided species are the same
            if (gameObject.CompareTag(collidedTag))
            {
                switch (collidedTag)
                {
                    case "Bear":
                        HandleCollision(bearPrefabs, ref bearCollisionCount, collision);
                        break;
                    case "Fisj":
                        HandleCollision(fishPrefabs, ref fishCollisionCount, collision);
                        break;
                    case "Rabbit":
                        HandleCollision(rabbitPrefabs, ref rabbitCollisionCount, collision);
                        break;
                    default:
                        break;
                }
            }
        }
    }


    void HandleCollision(GameObject[] prefabs, ref int collisionCount, Collision2D collision)
    {
        if (collisionCount < prefabs.Length)
        {
            EvolvePrefab(prefabs, ref collisionCount, collision);
        }
    }
    void EvolvePrefab(GameObject[] prefabs, ref int collisionCount, Collision2D collision)
    {
        // Get the position and rotation of the old prefab
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;

        // Get the replacement prefab with the corresponding index
        GameObject newPrefab = Instantiate(prefabs[collisionCount], position, rotation);
        
        // Increment collision count
        collisionCount++;

        // Destroy one of the collided objects
        Destroy(collision.gameObject);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject); // destroy the bullet out of the scene
    }


}
