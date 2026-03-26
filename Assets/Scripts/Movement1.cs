using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Windows;

public class Movement1 : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 input;
    public float speed = 4f;

    public bool moving1;

    public Animator animator;

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
        input.x = UnityEngine.Input.GetAxisRaw("Horizontal1");
        input.y =UnityEngine.Input.GetAxisRaw("Vertical1");

        input.Normalize();
        Animate();
    }
    public void Animate()
    {
        //Player1
        if (input.magnitude > 0.1f || input.magnitude < -0.1f)
        {
            animator.SetBool("Moving", true);
            moving1 = true;
        }
        else
        {
            animator.SetBool("Moving", false);
            moving1 = false;
        }
        if (moving1)
        {
            animator.SetFloat("x", input.x);
            animator.SetFloat("y", input.y);
        }
        //Player2

    }
}