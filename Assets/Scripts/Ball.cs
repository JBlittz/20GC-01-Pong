using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public event Action<float> OffScreen;

    [SerializeField]
    private AudioSource pointAudio;
    [SerializeField]
    private AudioSource paddleAudio;
    [SerializeField]
    private AudioSource wallAudio;

    private float speed = 40f;
    private Vector2 direction;
    private Rigidbody2D rb;

    void Start()
    {
        direction = new(Random.Range(0f, 1f) < 0.5f ? -1f : 1f, Random.Range(0f, 1f) < 0.5f ? -1f : 1f);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(direction.x, direction.y) * speed);
        pointAudio.Play();
    }
    
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")) {
            direction.y *= -1f;
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(new Vector2(direction.x, direction.y) * speed);
            wallAudio.Play();
        }
        if (collision.gameObject.CompareTag("Paddle"))
        {
            transform.position = new Vector3(1.75f * direction.x, transform.position.y, 0f);
            direction.x *= -1f;
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(new Vector2(direction.x, direction.y) * speed);
            paddleAudio.Play();
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.x <= -2.5f || transform.position.x >= 2.5f)
        {
            OffScreen?.Invoke(transform.position.x);
            transform.position = Vector3.zero;
            direction = new(UnityEngine.Random.Range(0f, 1f) < 0.5f ? -1f : 1f, UnityEngine.Random.Range(0f, 1f) < 0.5f ? -1f : 1f);
            rb.totalForce = Vector2.zero;
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(new Vector2(direction.x, direction.y) * speed);
            pointAudio.Play();
        }
    }
}
