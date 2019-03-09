using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public float speed;

    public GameObject effect;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            AudioManager.instance.PlayExplosionSound();
            Instantiate(effect, transform.position, Quaternion.identity);

            Player player = other.GetComponent<Player>();
            player.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
