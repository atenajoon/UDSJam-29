using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolvedSpecies : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        string speciesTag = collision.gameObject.tag;
        string collidedObjectTag = gameObject.tag;

        switch (speciesTag)
        {
            case "BearEgg" when collidedObjectTag == "Bear":
                // Destroy(gameObject);
                Destroy(collision.gameObject);
                break;

            case "FishEgg" when collidedObjectTag == "Fish":
                // Destroy(other.gameObject);
                // EvolveFish(position, rotation);
                break;
            case "RabbitEgg" when collidedObjectTag == "Rabbit":
                // Destroy(other.gameObject);
                // EvolveRabbit(position, rotation);
                break;
            default:
                break;                                                              
        }
    }
}
