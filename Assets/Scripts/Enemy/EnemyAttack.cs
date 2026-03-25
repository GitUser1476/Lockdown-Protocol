using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _damageAmount;
    [SerializeField] private string _playerTag = "Player";

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_playerTag))
        {
            HealthController healthController = collision.gameObject.GetComponent<HealthController>();

            if (healthController != null)
            {
                healthController.TakeDamage(_damageAmount);
            }
        }
    }
}