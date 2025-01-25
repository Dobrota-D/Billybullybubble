using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private TMP_Text m_Timer;
    [SerializeField] private TMP_Text m_TryCounter;
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

    public void IncrementDeathCount()
    {
        deathCounter++;
    }

    public void UpdateBubbleCounter(float nb)
    {
        m_TryCounter.text = "Essais : " + nb;
    }

    public void UpdateTimeCounter(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        m_Timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
