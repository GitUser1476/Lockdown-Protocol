using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BarikadaMicanje : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Barikada"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                foreach (Transform child in collision.gameObject.transform)
                {
                    Destroy(child.gameObject);
                    SceneManager.LoadScene("WinScreen");
                }
            }
        }
    }
}