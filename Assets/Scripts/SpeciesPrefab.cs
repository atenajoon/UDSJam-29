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
            if (gameObject.CompareTag(collidedTag))
            {

                // Modify the remaining object
                Transform transform = gameObject.transform;
                transform.localScale *= 1.2f; // Increase the size by 20%
                // Change the sprite to a different sprite
                Sprite newSprite = Resources.Load<Sprite>("fish_3"); // Change "NewSprite" to the name of your new sprite
                GetComponent<SpriteRenderer>().sprite = newSprite;

                Debug.Log("Species evolved");

                // Destroy one of the collided objects
                Destroy(collision.gameObject);
            }
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject); // destroy the bullet out of the scene
    }


}
