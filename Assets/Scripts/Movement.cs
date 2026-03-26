using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb1;
    public Rigidbody2D rb2;

    private Vector2 input1;
    private Vector2 input2;
    public float speed = 4f;

    private void Awake()
    {
        rb1 = GameObject.Find("Player1").GetComponent<Rigidbody2D>();
        rb2 = GameObject.Find("Player2").GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        rb1.velocity = input1 * speed;
        rb2.velocity = input2 * speed;
    }
    private void Update()
    {
        input1.x = Input.GetAxisRaw("Horizontal1");
        input1.y = Input.GetAxisRaw("Vertical1");

        input2.x = Input.GetAxisRaw("Horizontal2");
        input2.y = Input.GetAxisRaw("Vertical2");

        input1.Normalize();
        input2.Normalize();
    }

}
