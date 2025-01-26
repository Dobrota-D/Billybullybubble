using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Target
{
    Player,
    Bubble
}

public class TargetManager : MonoBehaviour
{

    [Header("HiveTarget")]
    [SerializeField] private GameObject m_Player;
    [SerializeField] private GameObject m_Bubble;

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
            Target.Player => m_Player,
            Target.Bubble => m_Bubble,
        };
    }
}
