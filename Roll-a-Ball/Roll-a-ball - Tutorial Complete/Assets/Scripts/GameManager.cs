using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text countText;
    public Text winText;
    public PlayerController playerController;

    private int count;

    private void Start()
    {
        count = 0;
        SetCountText();
        winText.text = "";
        playerController.OnColissionEvent += IncreaseScore;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        playerController.Move(moveHorizontal, moveVertical);
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }

    public void IncreaseScore()
    {
        count += 1;
        SetCountText();
    }
}
