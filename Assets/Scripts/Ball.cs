using System.Runtime.CompilerServices;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float speed = 30f;
    private Vector2 direction;
    private Rigidbody2D rb;
    
    void Start()
    {
        direction = new(Random.Range(0, 1) < 0.5f ? -1 : 1, Random.Range(0, 1) < 0.5f ? -1 : 1);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(direction.x, direction.y) * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")) {
            direction.y *= -1;
            rb.totalForce = new Vector2(direction.x, direction.y) * speed;
        }
        if (collision.gameObject.CompareTag("Paddle"))
        {
            direction.x *= -1;
            rb.totalForce = new Vector2(direction.x, direction.y) * speed;
        }
    }
}
