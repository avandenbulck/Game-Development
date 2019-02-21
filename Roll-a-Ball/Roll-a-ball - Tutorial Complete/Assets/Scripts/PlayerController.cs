using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public delegate void OnColission();
    public event OnColission OnColissionEvent;

    private Rigidbody rb;

    private float moveHorizontal;
    private float moveVertical;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(float moveHorizontal, float moveVertical)
    {
        this.moveHorizontal = moveHorizontal;
        this.moveVertical = moveVertical;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            OnColissionEvent.Invoke();
        }
    }
}
