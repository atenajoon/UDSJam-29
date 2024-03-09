using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private Dictionary<string, int> highestEvolutionLevels = new Dictionary<string, int>();
    private string lastEvolvedSpecies; // Tracks the last species type that evolved to level 3.

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    public void UpdateEvolutionLevel(string speciesType, int newLevel)
    {
        // Store the last species that evolved to level 3.
        if (newLevel == 3)
        {
            lastEvolvedSpecies = speciesType;
        }

        // Rest of the method remains the same...
    }

    public void TriggerWin(string speciesType)
    {
        // Handle the win condition when a creature reaches level 3.
        Debug.Log($"Game Over! {speciesType} reached its highest evolution level.");
        // Store the species that won for display on the main menu.
        lastEvolvedSpecies = speciesType;
        // Implement your win logic here.
    }

    public void TriggerGameOver()
    {
        // Handle the game over condition when the box is full.
        Debug.Log("Game Over: The box is full!");
        // Implement your game over logic here.
    }
    
    // Additional method to get the last evolved species for the main menu.
    public string GetLastEvolvedSpecies()
    {
        return lastEvolvedSpecies;
    }
}
