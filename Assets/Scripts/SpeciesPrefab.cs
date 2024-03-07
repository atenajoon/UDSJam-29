using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeciesPrefab : MonoBehaviour
{
    public float speciesWeight;

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
            if(gameObject.CompareTag(collidedTag))
            {
                // combine them to evolve
                Debug.Log("collidedTag: " + collidedTag);
                //  explode the other ones
            }
               
        }


    }
    void OnBecameInvisible()
    {
        Destroy(gameObject); // destroy the bullet out of the scene
    }


}
