using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolvedSpecies : MonoBehaviour
{
    // List to store collided objects
    private List<string> collidedObjects = new List<string>();


    void Update()
    {
        // Check if the list is not empty before accessing its elements
        if (collidedObjects.Count > 0)
        {
            // Print the name of the first element
            Debug.Log("2_ Name of the First Element: " + collidedObjects[0]);

            // Clear the list
            // collidedObjects.Clear();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        string speciesTag = collision.gameObject.tag;
        string collidedObjectTag = gameObject.tag;

        // if 2 similar items collide
        if (speciesTag == collidedObjectTag)
        {
            string collidedObjectName = collision.gameObject.name;
            // add the collision gameObject to the list
            collidedObjects.Add(collidedObjectName);
            // Debug.Log("1. list length: " + collidedObjects.Count);
            Destroy(collision.gameObject);
            Debug.Log("1_ collidedObjectName: " + collidedObjects[0]);

        }

    
    }
}
