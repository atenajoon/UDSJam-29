using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeciesPrefab : MonoBehaviour
{
    public int speciesWeight;
    void OnBecameInvisible()
    {
        Destroy(gameObject); // destroy the bullet out of the scene
    }
}
