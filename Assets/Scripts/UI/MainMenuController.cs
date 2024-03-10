using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image; // Required for changing scenes

public class MainMenuController : MonoBehaviour
{
    // Assign these buttons in the inspector
    public Button startButton;
    public Button creditsButton;
    public Button exitButton;

    public Image bearImage;
    public Sprite bearFirstSprite; // Reference to the final stage bear sprite set in the Inspector
    public Sprite bearFinalSprite; // Reference to the final stage bear sprite set in the Inspector
    public Image fishImage;
    public Sprite fishFirstSprite; // Reference to the final stage bear sprite set in the Inspector
    public Sprite fishFinalSprite; // Reference to the final stage bear sprite set in the Inspector
    public Image rabbitImage;
    public Sprite rabbitFirstSprite; // Reference to the final stage bear sprite set in the Inspector
    public Sprite rabbitFinalSprite; // Reference to the final stage bear sprite set in the Inspector

    public Image background;
    public Sprite BackgroundSprite1;
    public Sprite BackgroundSprite2;
    public Sprite BackgroundSprite3;

    private void Awake()
    {
        DisplayCreaturesBackground();

    }
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
    // Somewhere in your menu scene script
    void DisplayCreaturesBackground()
    {
        if (GameManager.Instance != null)
        {


            if (GameManager.Instance.scoreBoard["Bear"])
            {
                // Logic to display the bear image
                bearImage.sprite = bearFinalSprite;
                bearImage.color = Color.white;
                Debug.Log("scroreBOard bear:" + GameManager.Instance.scoreBoard["Bear"]);
            }
            else
            {
                bearImage.sprite = bearFirstSprite;
            }

            if (GameManager.Instance.scoreBoard["Fish"])
            {
                // Logic to display the fish image
                fishImage.sprite = fishFinalSprite;
                fishImage.color = Color.white;
                Debug.Log("scroreBOard fish:" + GameManager.Instance.scoreBoard["Fish"]);
            }
            else
            {
                fishImage.sprite = fishFirstSprite;
            }

            if (GameManager.Instance.scoreBoard["Rabbit"])
            {
                Debug.Log("scroreBOard rab:" + GameManager.Instance.scoreBoard["Rabbit"]);
                // Logic to display the rabbit image
                rabbitImage.sprite = rabbitFinalSprite;
                rabbitImage.color = Color.white;
            }
            else
            {
                rabbitImage.sprite = rabbitFirstSprite;
            }

            int collectedCount = CountCollectedFinalStages();
            Debug.Log("scroreBOard count:" + collectedCount);
            // Assuming you have different backgrounds for different counts
            background.sprite = collectedCount switch
            {
                1 => BackgroundSprite2,
                2 => BackgroundSprite3,
                3 => BackgroundSprite3,
                _ => BackgroundSprite3,
            };
        }
        else
        {
            Invoke(nameof(DisplayCreaturesBackground), 0.1f); // A slight delay to ensure GameManager is ready
        }
    }
    public int CountCollectedFinalStages()
    {
        int count = 0;
        foreach (var isCollected in GameManager.Instance.scoreBoard.Values)
        {
            if (isCollected)
            {
                count++;
            }
        }
        return count;
    }
}
