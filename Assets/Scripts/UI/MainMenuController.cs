using UnityEngine;
using UnityEngine.UI; // Required for interacting with UI elements like buttons
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl; // Required for changing scenes

public class MainMenuController : MonoBehaviour
{
    // Assign these buttons in the inspector
    public Button startButton;
    public Button creditsButton;
    public Button exitButton;

    private void Start()
    {
        // Add click listeners to the buttons
        startButton.onClick.AddListener(StartGame);
        creditsButton.onClick.AddListener(ShowCredits);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void StartGame()
    {
        // Load the MainScene
        SceneManager.LoadScene("MainScene");
    }

    private void ShowCredits()
    {
        // Load the Credits scene (adjust "CreditsScene" to your actual scene name once it's created)
        SceneManager.LoadScene("CreditsScene");
    }

    private void ExitGame()
    {
        // Quit the application (note: this will only work in a built game, not the Unity editor)
        Application.Quit();

        // If you want to be able to quit from the Unity editor, use the following line:
        // UnityEditor.EditorApplication.isPlaying = false;
    }
}
