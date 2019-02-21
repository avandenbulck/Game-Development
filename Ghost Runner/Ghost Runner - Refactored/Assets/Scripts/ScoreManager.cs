using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public delegate void OnScoreChanged(int newScore);
    public event OnScoreChanged OnScoreChangedEvent;

    private void Start()
    {
        OnScoreChangedEvent.Invoke(0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            score++;
            OnScoreChangedEvent.Invoke(score);
        }
    }
}
