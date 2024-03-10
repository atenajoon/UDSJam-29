using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StopMenu : MonoBehaviour
{
    private bool isPaused = false;
    private bool isMuted = false;
    private bool canClickQuit = false;
    private VisualElement stopMenu; // Make sure stopMenu is accessible throughout the class

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        stopMenu = root.Q<VisualElement>("StopMenu");
        Button buttonResume = root.Q<Button>("buttonResume");
        Button buttonAudio = root.Q<Button>("buttonAudio");
        Button buttonQuit = root.Q<Button>("buttonQuit");

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

    void ResumeGame()
    {
        Time.timeScale = 1f;
        StartCoroutine(AnimateStopMenuOut()); // Start the animation coroutine to slide out the menu
    }


}
