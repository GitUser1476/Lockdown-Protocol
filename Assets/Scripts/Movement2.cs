using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Movement2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 input;
    public float speed = 4f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = input * speed;
    }
    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal2");
        input.y = Input.GetAxisRaw("Vertical2");

        input.Normalize();
    }
}
