using UnityEngine;
using System.Collections.Generic;

public class Box : MonoBehaviour
{
    [SerializeField] private int maxCapacity = 10; // Set this to the maximum number of creatures the box can hold.
    private List<SpeciesPrefab> creaturesInBox = new List<SpeciesPrefab>(); // List to keep track of creatures currently in the box.

    void OnTriggerEnter2D(Collider2D collider)
    {
        SpeciesPrefab creature = collider.GetComponent<SpeciesPrefab>();

        // If the colliding object is a creature and the box isn't full
        if (creature && creaturesInBox.Count < maxCapacity)
        {
            creaturesInBox.Add(creature); // Add the creature to the box's list

            // Attempt to evolve the creature with any matching species in the box
            AttemptEvolution(creature);
        }
        else if (creaturesInBox.Count >= maxCapacity)
        {
            // Box is full, trigger lose condition
            GameManager.Instance.TriggerGameOver();
        }
    }

    private void AttemptEvolution(SpeciesPrefab newCreature)
    {
        // Find another creature of the same type and level to evolve
        SpeciesPrefab match = creaturesInBox.Find(c => c.speciesType == newCreature.speciesType && c.speciesLevel == newCreature.speciesLevel);
        if (match != null)
        {
            // Evolve the creatures
            EvolveCreatures(newCreature, match);
        }
    }

    private void EvolveCreatures(SpeciesPrefab creature1, SpeciesPrefab creature2)
    {
        // Assume each SpeciesPrefab knows its next evolution prefab
        // GameObject nextEvolutionPrefab = creature1.nextEvolutionPrefab;
        // if (nextEvolutionPrefab)
        // {
        //     // Spawn the evolved creature and set its properties
        //     Vector3 spawnPosition = (creature1.transform.position + creature2.transform.position) / 2;
        //     SpeciesPrefab evolvedCreature = Instantiate(nextEvolutionPrefab, spawnPosition, Quaternion.identity).GetComponent<SpeciesPrefab>();
        //     evolvedCreature.speciesWeight = creature1.speciesWeight * 2; // Double the weight of the new evolved creature

        //     creaturesInBox.Remove(creature1); // Remove the creatures from the box's list
        //     creaturesInBox.Remove(creature2);

        //     Destroy(creature1.gameObject); // Destroy the previous creatures
        //     Destroy(creature2.gameObject);

        //     creaturesInBox.Add(evolvedCreature); // Add the new evolved creature to the box's list
        //     GameManager.Instance.UpdateEvolutionLevel(evolvedCreature.speciesType, evolvedCreature.speciesLevel); // Update the evolution level in GameManager
        // }
        // else
        // {
        // If there is no next evolution prefab, we've reached the highest evolution
        Debug.Log(creature1.speciesType + " has reached its highest evolution.");
        // }
    }
}
