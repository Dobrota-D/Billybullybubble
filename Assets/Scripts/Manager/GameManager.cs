using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Playing,
    Gameover,
    PlayerDeath
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    
    private GameState _state;

    public AudioSource _audioSource;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        
        if (Instance == null) // If there is no instance already
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(Instance);
    }

    void Start()
    {
        _state = GameState.Playing;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case GameState.Playing:
                UpdatePlayingGame();
                break;
            case GameState.PlayerDeath:
                break;
            case GameState.Gameover:
                break;
        }
    }

    void UpdatePlayingGame()
    {
        UIManager.Instance.UpdateTimeCounter(Time.time);
    }

    public void PlayerDeath()
    {
        Debug.Log("PlayerDeath");
        // Coroutine
        TargetManager.Instance.GetGameObject(Target.Player).GetComponent<PlayerController>().PlayerDeath();
        UIManager.Instance.IncrementDeathCount();
    }

    public void SetGameState(GameState state)
    {
        _state = state;
    }

    public bool IsPlayerDead()
    {
        return (_state == GameState.PlayerDeath);
    }
}
