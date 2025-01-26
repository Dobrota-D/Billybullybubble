using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

enum GameState
{
    Menu,
    Playing,
    Gameover,
    PlayerDeath
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public PlayerController _player;
    
    private static bool _created = false;
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
        // UIManager.Instance.UpdateTimeCounter(0f);
    }


    void UpdatePlayingGame()
    {
        UIManager.Instance.UpdateTimeCounter(Time.time);
    }

    public void PlayerDeath()
    {
        Debug.Log("PlayerDeath");
        SetGameState(GameState.PlayerDeath);
        
        // Coroutine
        _player.PlayerDeath();
        _uiManager.IncrementDeathCount();
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        SetGameState(GameState.Playing);
    }
    
    void SetGameState(GameState state)
    {
        _state = state;
    }

    public bool IsPlayerDead()
    {
        return (_state == GameState.PlayerDeath);
    }
}
