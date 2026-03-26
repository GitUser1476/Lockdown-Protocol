using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private string _playerTag = "Player";

    private IColectableBehaviour _collectableBehaviour;

    private void Awake()
    {
        _collectableBehaviour = GetComponent<IColectableBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag(_playerTag))
        {
            return;
        }

        if (_collectableBehaviour != null)
        {
            _collectableBehaviour.OnCollected(collision.gameObject);
        }

        Destroy(gameObject);
    }
}