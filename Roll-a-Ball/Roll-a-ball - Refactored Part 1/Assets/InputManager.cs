using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public GameController gameController;
    public Text countText;
    public Text winText;

    void Awake()
    {
        winText.text = "";
        gameController.OnCountChangedEvent += SetCount;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        gameController.MovePlayer(moveHorizontal, moveVertical);
    }

    public void SetCount(int count)
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }

    public void ShowWinText()
    {
        winText.text = "You Win!";
    }
}
