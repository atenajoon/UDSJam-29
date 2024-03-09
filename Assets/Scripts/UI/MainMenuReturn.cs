using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for interacting with UI elements like buttons
using UnityEngine.SceneManagement; // Required for changing scenes

public class MainMenuReturn : MonoBehaviour
{
    public Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        backButton.onClick.AddListener(BackToMenu);
    }

    private void BackToMenu()
    {
        // Load main menu
        SceneManager.LoadScene("MenuScene");
    }
}
