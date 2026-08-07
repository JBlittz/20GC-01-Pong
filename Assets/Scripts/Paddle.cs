using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private InputActionReference inputActionReference;
    private InputAction move;
    private float speed = 0.01f;

    private void Awake()
    {
        move = inputActionReference.action;
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(0, move.ReadValue<float>() * speed, 0));
        transform.position = new Vector3(transform.position.x, Math.Clamp(transform.position.y, -1, 1), 0);
    }
}
