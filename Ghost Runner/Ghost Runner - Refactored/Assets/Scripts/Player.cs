using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public Transform topLocation;
    public Transform middleLocation;
    public Transform bottomLocation;
    public float speed;
    public GameObject effect;

    public GameObject gameOver;

    private Vector2 targetPos;
    private int health = 3;
    private PositionState positionState;

    public event Action<int> OnHealthChangedEvent;

    void Start()
    {
        positionState = PositionState.Middle;
        OnHealthChangedEvent.Invoke(health);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    public void Move(MoveAction moveAction)
    {  
        if(health > 0)
        {
            if (moveAction == MoveAction.Up && positionState != PositionState.Top)
            {
                Move(positionState + 1);
            }
            else if (moveAction == MoveAction.Down && positionState != PositionState.Bottom)
            {
                Move(positionState - 1);
            }
        }
    }

    private void Move(PositionState newPositionState)
    {       
        switch (newPositionState)
        {
            case PositionState.Top:
                Move(topLocation.position);
                break;
            case PositionState.Middle:
                Move(middleLocation.position);
                break;
            case PositionState.Bottom:
                Move(bottomLocation.position);
                break;
        }
        positionState = newPositionState;
    }

    private void Move(Vector2 newPosition)
    {
        PlayParticleEffect();
        targetPos = newPosition;
    }

    private void PlayParticleEffect()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
    }

    public void DealDamage(int amount)
    {
        int newHealth = health - amount;
        health = Mathf.Max(newHealth, 0);

        if (health <= 0)
        {
            gameOver.SetActive(true);
            this.gameObject.SetActive(false);
        }

        OnHealthChangedEvent.Invoke(health);
    }

    public enum PositionState
    {
        Bottom, Middle, Top
    }

    public enum MoveAction
    {
        Up, Down
    }
}
