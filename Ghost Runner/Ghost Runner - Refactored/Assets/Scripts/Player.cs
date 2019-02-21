using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 targetPos;
    public Transform topLocation;
    public Transform middleLocation;
    public Transform bottomLocation;

    public float speed;
    public float maxHeight;
    public float minHeight;

    private int health = 3;
    private PositionState positionState;

    public GameObject effect;
    public Text healthDisplay;

    public GameObject gameOver;

    private void Start()
    {
        UpdateHealthUI();
        positionState = PositionState.Middle;
    }

    void Update()
    {     
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && positionState != PositionState.Top)
        {
            Move(positionState + 1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && positionState != PositionState.Bottom)
        {
            Move(positionState - 1);
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
            Destroy(gameObject);
        }

        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        healthDisplay.text = health.ToString();
    }

    public enum PositionState
    {
        Bottom, Middle, Top
    }
}
