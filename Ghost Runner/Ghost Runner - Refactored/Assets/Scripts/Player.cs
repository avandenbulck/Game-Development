using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 targetPos;
    public float yIncrement;

    public float speed;
    public float maxHeight;
    public float minHeight;

    private int health = 3;

    public GameObject effect;
    public Text healthDisplay;

    public GameObject gameOver;

    private void Start()
    {
        UpdateHealthUI();
    }

    void Update()
    {     
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            Move(yIncrement);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            Move(-yIncrement);
        }
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

    private void Move(float yIncrement)
    {
        PlayParticleEffect();
        targetPos = new Vector2(transform.position.x, transform.position.y + yIncrement);
    }

    private void PlayParticleEffect()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
    }
}
