using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public delegate void OnCollision();
    public event OnCollision OnCollisionEvent;

    private Rigidbody rb;

    float moveHorizontal;
    float moveVertical;

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
            OnCollisionEvent.Invoke();
        }
    }
}
