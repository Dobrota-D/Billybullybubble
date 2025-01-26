using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public int deathCounter = 0;

    public static UIManager Instance = null;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null) // If there is no instance already
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    private void Update()
    {
        UpdateBubbleCounter();
    }

    public void IncrementDeathCount()
    {
        deathCounter++;
    }

    public void UpdateBubbleCounter()
    {
        TargetManager.Instance.GetText(UI.TryCounter).text = "Essais : " + deathCounter;
    }

    public void UpdateTimeCounter(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        TargetManager.Instance.GetText(UI.Timer).text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
