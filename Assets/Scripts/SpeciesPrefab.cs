using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeciesPrefab : MonoBehaviour
{
    public float speciesWeight;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
