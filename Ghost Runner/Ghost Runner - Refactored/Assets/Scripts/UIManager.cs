using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Player player;
    public Text healthDisplay;

    public ScoreManager scoreManager;
    public Text scoreDisplay;

    // Start is called before the first frame update
    void Awake()
    {
        player.OnHealthChangedEvent += UpdateHealthUI;
        scoreManager.OnScoreChangedEvent += UpdateScoreUI;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.Move(Player.MoveAction.Up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            player.Move(Player.MoveAction.Down);
        }
    }

    private void UpdateHealthUI(int newHealth)
    {
        healthDisplay.text = newHealth.ToString();
    }

    private void UpdateScoreUI(int newScore)
    {
        scoreDisplay.text = newScore.ToString();
    }
}
