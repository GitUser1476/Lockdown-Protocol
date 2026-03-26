using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstKey : MonoBehaviour
{
    private bool firstKeyInHand = true;

    public Collider2D barikada;

    private void Start()
    {
        barikada = GetComponent<Collider2D>();
    }

    private void OnCollision2D(Collision2D collision)
    {
        Debug.Log("Sudario si se jebem te tulava");
        if (Input.GetKeyDown(KeyCode.E) && Input.GetKeyDown(KeyCode.KeypadDivide) )
        {
            barikada.isTrigger = true;
        }
    }
}