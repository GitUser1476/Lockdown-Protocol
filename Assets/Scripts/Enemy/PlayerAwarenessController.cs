using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }
    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField] private float _playerAwarenessDistance;
    [SerializeField] private string _playerTag = "Player";

    private GameObject[] _players;

    private void Update()
    {
        _players = GameObject.FindGameObjectsWithTag(_playerTag);

        if (_players == null || _players.Length == 0)
        {
            AwareOfPlayer = false;
            DirectionToPlayer = Vector2.zero;
            return;
        }

        float closestDistance = Mathf.Infinity;
        Transform closestPlayer = null;

        foreach (GameObject player in _players)
        {
            if (player == null)
            {
                continue;
            }

            Vector2 enemyToPlayerVector = (Vector2)(player.transform.position - transform.position);
            float distance = enemyToPlayerVector.magnitude;

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPlayer = player.transform;
            }
        }

        if (closestPlayer != null && closestDistance <= _playerAwarenessDistance)
        {
            Vector2 enemyToPlayerVector = (Vector2)(closestPlayer.position - transform.position);
            DirectionToPlayer = enemyToPlayerVector.normalized;
            AwareOfPlayer = true;
        }
        else
        {
            DirectionToPlayer = Vector2.zero;
            AwareOfPlayer = false;
        }
    }
}