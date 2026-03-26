using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Movement2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 input;
    public float speed = 4f;

    public bool moving2;

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
        input.x = UnityEngine.Input.GetAxisRaw("Horizontal2");
        input.y = UnityEngine.Input.GetAxisRaw("Vertical2");

        input.Normalize();
        Animate();
    }
    public void Animate()
    {
        //Player1
        if (input.magnitude > 0.1f || input.magnitude < -0.1f)
        {
            animator.SetBool("Moving", true);
            moving2 = true;
        }
        else
        {
            animator.SetBool("Moving", false);
            moving2 = false;
        }
        if (moving2)
        {
            animator.SetFloat("x", input.x);
            animator.SetFloat("y", input.y);
        }
        //Player2

    }
}
