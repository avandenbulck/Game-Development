using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 targetPos;
    public float YIncrement;

    public float speed;
    public float maxHeight;
    public float minHeight;

    public int health = 3;

    public GameObject effect;
    public Text healthDisplay;

    public GameObject gameOver;

    void Update()
    {
        healthDisplay.text = health.ToString();

        if(health <= 0)
        {
            gameOver.SetActive(true);
            Destroy(gameObject);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            Move(YIncrement);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            Move(-YIncrement);
        }
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
