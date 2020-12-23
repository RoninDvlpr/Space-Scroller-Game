using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    Playing,
    Paused,
    NotPlaying
}

public class GameManager : MonoBehaviour
{
    [SerializeField] UnityEvent gameStarted, gameFinished, gamePaused, gameUnpaused;    
    GameState state = GameState.NotPlaying;
    public static GameState State
    {
        get
        {
            if (instance == null)
                Debug.Log("There is no GameManager instaces in the scene!");

            return instance.state;
        }
    }

    //singleton
    static GameManager instance;

    void Awake()
    {
        SetInstance();
    }

    void SetInstance()
    {
        if (instance == null)
            instance = this;
        else
            Debug.Log("There is two GameManager instaces in the scene!");
    }
    
    public void StartPlaying()
    {
        if (state == GameState.Paused)
            Pause(false);
        else
        {
            gameStarted?.Invoke();
            state = GameState.Playing;
        }
    }

    public void StopPlaying()
    {
        gameFinished?.Invoke();
        state = GameState.NotPlaying;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (state == GameState.Playing)
                Pause(true);
            else     
                Application.Quit();
    }

    void Pause(bool pause)
    {
        if (pause)
        {
            gamePaused?.Invoke();
            Time.timeScale = 0f;
            state = GameState.Paused;
        }
        else
        {
            gameUnpaused?.Invoke();
            Time.timeScale = 1f;
            state = GameState.Playing;
        }
    }
}
