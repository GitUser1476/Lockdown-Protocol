using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _damageAmount = 10f;
    [SerializeField] private float _attackCooldown = 0.5f;
    [SerializeField] private string _playerTag = "Player";

    private Dictionary<GameObject, float> _nextDamageTime = new Dictionary<GameObject, float>();

    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject otherObject = collision.gameObject;

        if (!otherObject.CompareTag(_playerTag))
        {
            return;
        }

        HealthController healthController = otherObject.GetComponent<HealthController>();

        if (healthController == null)
        {
            return;
        }

        if (!_nextDamageTime.ContainsKey(otherObject))
        {
            _nextDamageTime[otherObject] = 0f;
        }

        if (Time.time >= _nextDamageTime[otherObject])
        {
            healthController.TakeDamage(_damageAmount);
            _nextDamageTime[otherObject] = Time.time + _attackCooldown;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GameObject otherObject = collision.gameObject;

        if (_nextDamageTime.ContainsKey(otherObject))
        {
            _nextDamageTime.Remove(otherObject);
        }
    }
}