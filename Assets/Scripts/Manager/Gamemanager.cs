using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum GameState
{
    Menu,
    Playing,
    Gameover
}

public class Gamemanager : MonoBehaviour
{
    private static bool _created = false;

    private GameState _state;

    public static Gamemanager Instance = null;
    private UIManager _uiManager;
    private void Awake()
    {
        if (Instance == null) // If there is no instance already
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
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
            case GameState.Gameover:
                string currentSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentSceneName);
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

    public void GameOver()
    {
        _uiManager.IncrementDeathCount();
        Debug.Log("Game Over");
        SetGameState(GameState.Gameover);
    }

    void SetGameState(GameState state)
    {
        _state = state;
    }
}
