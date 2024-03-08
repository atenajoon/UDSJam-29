using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolvedSpecies : MonoBehaviour
{
    // List to store collided objects
    private List<GameObject> collidedObjects = new List<GameObject>();

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        string speciesTag = collision.gameObject.tag;
        string collidedObjectTag = gameObject.tag;

        // if 2 similar items collide
        if (speciesTag == collidedObjectTag)
        {
            Debug.Log("similar");
            collidedObjects.Add(collision.gameObject);
            Destroy(gameObject);
        }

        // Example: Print the names of collided objects in the list
        foreach (GameObject obj in collidedObjects)
        {
            Debug.Log("Collided Object: " + obj.name);
        }
    }
}
