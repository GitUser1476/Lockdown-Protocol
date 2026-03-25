using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Windows;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb1;
    public Rigidbody2D rb2;

    private Vector2 input1;
    private Vector2 input2;
    public float speed = 4f;

    public bool moving1;
    public bool moving2;
    public Animator animator1;
    public Animator animator2;
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
        input1.x = UnityEngine.Input.GetAxisRaw("Horizontal1");
        input1.y = UnityEngine.Input.GetAxisRaw("Vertical1");

        input2.x = UnityEngine.Input.GetAxisRaw("Horizontal2");
        input2.y = UnityEngine.Input.GetAxisRaw("Vertical2");

        
        input1.Normalize();
        input2.Normalize();
        Animate();

    }


    public void Animate()
    {
        //Player1
        if (input1.magnitude > 0.1f || input1.magnitude < -0.1f)
        {
            animator1.SetBool("Moving", true);
            moving1 = true;
        }
        else
        {
            animator1.SetBool("Moving", false);
            moving1 = false;
        }
        if (moving1)
        {
            animator1.SetFloat("x", input1.x);
            animator1.SetFloat("y", input1.y);
        }
        //Player2
        if (input2.magnitude > 0.1f || input2.magnitude < -0.1f)
        {
            animator2.SetBool("Moving", true);
            moving2 = true;
        }
        else
        {
            animator2.SetBool("Moving", false);
            moving2 = false;
        }
        if (moving2)
        {
            animator2.SetFloat("x", input2.x);
            animator2.SetFloat("y", input2.y);
        }
    }
}

