using UnityEngine;

public class SpeciesPrefab : MonoBehaviour
{
    public float speciesWeight;
    public int speciesLevel; // The level should be set on the prefab, 0 for _0, 1 for _1, etc.
    public string speciesType; // The type should be set on the prefab, "Bear", "Fish", "Rabbit", "Null"

    public GameObject[] evolutionPrefabs; // Assign prefabs for each evolution level in the inspector, in order

    private void Start()
    {
        if (speciesType == "Null")
        {
            Destroy(gameObject, 5f); // Destroy Null creatures after 5 seconds.
        }
    }

    public void Evolve()
    {
        if (speciesLevel < evolutionPrefabs.Length - 1)
        {
            Vector3 position = transform.position;
            Quaternion rotation = Quaternion.identity;
            _ = Instantiate(evolutionPrefabs[speciesLevel + 1], position, rotation);

            // Destroy the current creature as it has now evolved
            Destroy(gameObject);
            // Make sure to also destroy the other creature that was involved in the evolution
            // You might need to pass it as a parameter or store a reference to it
        }
        else
        {
            // This is the highest evolution, can't evolve further
            Debug.Log(speciesType + " has reached its highest evolution.");
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        SpeciesPrefab other = collision.gameObject.GetComponent<SpeciesPrefab>();

        // Ensure only one object handles the evolution process to avoid duplicate evolution
        if (other != null && other.speciesType == speciesType && other.speciesLevel == speciesLevel)
        {
            if (gameObject.GetInstanceID() < collision.gameObject.GetInstanceID())
            {
                Evolve();
                other.gameObject.SetActive(false); // Temporarily disable the other object to avoid multiple collisions
            }
        }
        // Additional collision handling...
    }
}

