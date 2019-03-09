using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public PlayerController playerController;
    public int scoreToWin;
    
    public event Action<int> OnCountChangedEvent;
    public UnityEvent OnWinEvent; //Alternative to the above event/Action approach;

    private int count;
    private GameState gameState;

    void Awake()
    {
        count = 0;
        gameState = GameState.Playing;
        playerController.OnCollisionEvent += IncreaseCount;
    }

    void Start()
    {
        OnCountChangedEvent.Invoke(count);
    }

    public void MovePlayer(float moveHorizontal, float moveVertical)
    {
        if(gameState == GameState.Playing)
            playerController.Move(moveHorizontal, moveVertical);
    }

    public void IncreaseCount()
    {
        count += 1;
        OnCountChangedEvent.Invoke(count);
        if (count >= scoreToWin && gameState == GameState.Playing)
        {
            OnWinEvent.Invoke();
            gameState = GameState.Won;
        }   
    }

    private enum GameState
    {
        Playing,
        Won
    }
}
