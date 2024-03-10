using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StopMenu : MonoBehaviour
{
    public static StopMenu Instance { get; private set; }
    private VisualElement winPopup;
    private VisualElement lostPopup;
    private bool isPaused = false;
    private bool isMuted = false;
    private bool canClickQuit = false;
    private VisualElement stopMenu; // Make sure stopMenu is accessible throughout the class

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        stopMenu = root.Q<VisualElement>("StopMenu");
        Button buttonResume = root.Q<Button>("buttonResume");
        Button buttonAudio = root.Q<Button>("buttonAudio");
        Button buttonQuit = root.Q<Button>("buttonQuit");
        winPopup = root.Q<VisualElement>("WonPopup");
        lostPopup = root.Q<VisualElement>("LostPopup");

        buttonResume.clicked += () =>
        {
            Debug.Log("resume clicked");
            isPaused = false;
            ResumeGame();
        };

        buttonAudio.clicked += () =>
        {
            Debug.Log("audio clicked");
            ToggleMute();
        };

        buttonQuit.RegisterCallback<PointerEnterEvent>(e =>
        {
            canClickQuit = false;
            Debug.Log("quit entered");
            StartCoroutine(EnableQuitAfterDelay(1f));
        });
        buttonQuit.RegisterCallback<PointerLeaveEvent>(e =>
        {
            StopAllCoroutines();
        });

        buttonQuit.clicked += () =>
        {
            if (canClickQuit)
            {
                Debug.Log("quit clicked");
                SceneManager.LoadScene("MenuScene");
            }
        };

    }

    // Call this method to display the win popup
    public void ShowWinPopup(string speciesType)
    {
        if (winPopup != null)
        {
            winPopup.style.display = DisplayStyle.Flex; // Or another way to make it visible depending on your UI setup

            // Find the correct image to display based on speciesType
            // Assuming you have images with the IDs "BearWin", "FishWin", "RabbitWin"
            string imageId = speciesType + "Win"; // e.g., "BearWin"
            VisualElement speciesImage = winPopup.Q<VisualElement>(imageId);
            if (speciesImage != null)
            {
                speciesImage.style.display = DisplayStyle.Flex; // Show the correct image
            }
            Button goMainMenu = winPopup.Q<Button>("buttonMainMenu");
            goMainMenu.clicked += () =>
            {
                Debug.Log("quit clicked");
                SceneManager.LoadScene("MenuScene");
            };
            GameEnd();
            // Optionally, hide other images if they are not already hidden by default
        }
    }
    // Call this method to display the win popup
    public void ShowLostPopup()
    {
        if (lostPopup != null)
        {
            lostPopup.style.display = DisplayStyle.Flex; // Or another way to make it visible depending on your UI setup
            Button goMainMenu = lostPopup.Q<Button>("buttonMainMenu");
            goMainMenu.clicked += () =>
            {
                Debug.Log("quit clicked");
                SceneManager.LoadScene("MenuScene");
            };
            GameEnd();
        }
    }
    private void ToggleMute()
    {
        isMuted = !isMuted; // Toggle the mute state
        AudioListener.volume = isMuted ? 0 : 1; // Set the volume to 0 if muted, 1 otherwise
        // Update button visual/text to indicate mute state, if necessary
        // e.g., buttonAudio.text = isMuted ? "Unmute" : "Mute";
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    IEnumerator AnimateStopMenuIn()
    {
        float duration = 0.5f;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.unscaledDeltaTime;
            float percentage = elapsed / duration;
            float leftValue = Mathf.Lerp(-33, 0, percentage);
            stopMenu.style.left = new Length(leftValue, LengthUnit.Percent);
            yield return null;
        }
        stopMenu.style.left = new Length(0, LengthUnit.Percent);
    }

    IEnumerator AnimateStopMenuOut()
    {
        float duration = 0.5f;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.unscaledDeltaTime;
            float percentage = elapsed / duration;
            float leftValue = Mathf.Lerp(0, -33, percentage);
            stopMenu.style.left = new Length(leftValue, LengthUnit.Percent);
            yield return null;
        }
        stopMenu.style.left = new Length(-33, LengthUnit.Percent); // Ensure it ends exactly at -33%
    }
    private IEnumerator EnableQuitAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay); // Use WaitForSecondsRealtime since Time.timeScale might be 0
        canClickQuit = true;
    }
    void PauseGame()
    {
        Time.timeScale = 0f;
        StartCoroutine(AnimateStopMenuIn());
    }
    void GameEnd()
    {
        Time.timeScale = 0f;
    }
    public void GameStart()
    {
        Time.timeScale = 1f;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        StartCoroutine(AnimateStopMenuOut()); // Start the animation coroutine to slide out the menu
    }


}
