using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GameState
{
    Menu,
    Playing,
    Gameover
}

public class Gamemanager : MonoBehaviour
{
    private GameState _state;

    public static Gamemanager Instance = null;
    private void Awake()
    {
        if (Instance == null) // If there is no instance already
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
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
}
