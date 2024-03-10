using System.Collections;
using UnityEngine;

public class SpeciesPrefab : MonoBehaviour
{
    public float speciesWeight;
    public int speciesLevel; // The level should be set on the prefab, 0 for _0, 1 for _1, etc.
    public string speciesType; // The type should be set on the prefab, "Bear", "Fish", "Rabbit", "Null"
    [Range(1, 4)]
    public int maxEvolve = 4;
    public float outsideBoxDeathTime = 5f;
    public GameObject[] evolutionPrefabs; // Assign prefabs for each evolution level in the inspector, in order

    private bool canEvolve = true; // Flag to indicate if the object is eligible for evolution
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
            if (speciesLevel == 3)
            {
                GameManager.Instance.TriggerWin(speciesType);
            }
        }
        else
        {
            // This is the highest evolution, can't evolve further
            Debug.Log(speciesType + " has reached its highest evolution.");
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Once on the ground, the creature should no longer be eligible for evolution
            canEvolve = false;

            // Start the coroutine to destroy the creature after 5 seconds
            StartCoroutine(DestroyAfterDelay(outsideBoxDeathTime));
        }

        if (canEvolve && speciesType != "Null")
        {
            // Logic for handling collision with the box
            SpeciesPrefab other = collision.gameObject.GetComponent<SpeciesPrefab>();

            // Ensure only one object handles the evolution process to avoid duplicate evolution
            if (other != null && other.speciesType == speciesType && other.speciesLevel == speciesLevel)
            {
                if (speciesLevel == maxEvolve - 1)
                {
                    GameManager.Instance.TriggerWin(speciesType);
                }
                else if (gameObject.GetInstanceID() < collision.gameObject.GetInstanceID())
                {
                    Evolve();
                    other.gameObject.SetActive(false); // Temporarily disable the other object to avoid multiple collisions
                }
            }

        }

    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}

