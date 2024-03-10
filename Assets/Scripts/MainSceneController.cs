using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneController : MonoBehaviour
{
    public SpriteRenderer backgroundRenderer; // Assign in the Inspector
    public Sprite defaultBackground; // Assign in the Inspector
    public Sprite oneCollectedBackground; // Assign in the Inspector
    public Sprite allCollectedBackground; // Assign in the Inspector

    void Start()
    {
        UpdateBackgroundBasedOnCollection();
    }

    void UpdateBackgroundBasedOnCollection()
    {
        StopMenu.Instance.GameStart();

        int collectedCount = GameManager.Instance.GetCollectedFinalCount();

        backgroundRenderer.sprite = collectedCount switch
        {
            1 => oneCollectedBackground,
            2 => allCollectedBackground,
            3 => allCollectedBackground,
            _ => defaultBackground,
        };
    }
}

