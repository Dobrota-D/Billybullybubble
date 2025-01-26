using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public enum Target
{
    Ghost,
    Bubble,
    Player
}
public enum UI
{
    Timer,
    TryCounter
}

public class TargetManager : MonoBehaviour
{

    [FormerlySerializedAs("m_Player")]
    [Header("HiveTarget")]
    [SerializeField] private GameObject m_Ghost;
    [SerializeField] private GameObject m_Bubble;
    [FormerlySerializedAs("m_PlayerController")]
    [SerializeField] private GameObject m_Player;

    [Header("Text")]
    [SerializeField] private TMP_Text m_Timer;
    [SerializeField] private TMP_Text m_TryCounter;

    public static TargetManager Instance; // A static reference to the TargetManager instance

    void Awake()
    {
        if (Instance == null) // If there is no instance already
            Instance = this;
        else if (Instance != this) // If there is already an instance and it's not `this` instance
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
    }

    public GameObject GetGameObject(Target t)
    {
        return t switch
        {
            Target.Ghost => m_Ghost,
            Target.Bubble => m_Bubble,
            Target.Player => m_Player
        };
    }

    public TMP_Text GetText(UI t)
    {
        return t switch
        {
            UI.Timer => m_Timer,
            UI.TryCounter => m_TryCounter
        };
    }
}
