using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Menu,
    Playing,
    Gameover,
    PlayerDeath
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    
    private GameState _state;
    private UIManager _uiManager;

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
        _uiManager = FindObjectOfType<UIManager>();
        _state = GameState.Menu;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case GameState.Menu:
                UpdateGameMenu();
                break;
            case GameState.Playing:
                UpdatePlayingGame();
                break;
            case GameState.PlayerDeath:
                break;
            case GameState.Gameover:
                break;
        }
    }

    void UpdateGameMenu()
    {
         UIManager.Instance.UpdateTimeCounter(0f);
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
        _uiManager.IncrementDeathCount();
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
