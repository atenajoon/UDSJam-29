using UnityEngine;
using System.Collections.Generic;

public class Box : MonoBehaviour
{
    [SerializeField] private int maxCapacity = 5000; // Set this to the maximum number of creatures the box can hold.
    private List<SpeciesPrefab> creaturesInBox = new List<SpeciesPrefab>(); // List to keep track of creatures currently in the box.

    void OnTriggerEnter2D(Collider2D collider)
    {
        SpeciesPrefab creature = collider.GetComponent<SpeciesPrefab>();

        // If the colliding object is a creature and the box isn't full
        if (creature && creaturesInBox.Count < maxCapacity)
        {
            creaturesInBox.Add(creature); // Add the creature to the box's list
            // Attempt to evolve the creature with any matching species in the box
        }
        else if (creaturesInBox.Count >= maxCapacity)
        {
            // Box is full, trigger lose condition
            GameManager.Instance.TriggerGameOver();
        }
    }

}
