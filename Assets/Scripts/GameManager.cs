using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Dictionary<string, bool> scoreBoard = new()
    {
        { "Bear", false },
        { "Fish", false },
        { "Rabbit", false }
    };
    private string lastEvolvedSpecies; // Tracks the last species type that evolved to level 3.

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Ensure the GameManager persists across scenes
        }
        else
        {
            Destroy(gameObject);
        }

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
    // Method to return the count of creatures collected at their final stage
    public int GetCollectedFinalCount()
    {
        return scoreBoard.Count(entry => entry.Value == true);
    }
    public void TriggerWin(string speciesType)
    {
        // Handle the win condition when a creature reaches level 3.
        Debug.Log($"Game Over! {speciesType} reached its highest evolution level.");

        // Store the species that won for display on the main menu.
        lastEvolvedSpecies = speciesType;
        scoreBoard[speciesType] = true;
        Debug.Log("scroreBOard:" + speciesType + scoreBoard[speciesType]);
        // Call UI method to display the win popup
        StopMenu.Instance.ShowWinPopup(speciesType);
    }

    public void TriggerGameOver()
    {
        // Handle the game over condition when the box is full.
        Debug.Log("Game Over: The box is full!");
        // Implement your game over logic here.
        // Call UI method to display the win popup
        StopMenu.Instance.ShowLostPopup();
    }

    // Additional method to get the last evolved species for the main menu.
    public string GetLastEvolvedSpecies()
    {
        return lastEvolvedSpecies;
    }
}
