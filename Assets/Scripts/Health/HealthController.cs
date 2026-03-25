using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float _currentHealt;

    [SerializeField] private float _maximumHealt;

    public float remainingHealthPercentage
    {
        get
        {
            return _currentHealt / _maximumHealt;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if(_currentHealt == 0)
        {
            return;
        }

        _currentHealt -= damageAmount;

        if (_currentHealt < 0)
        {
            _currentHealt = 0;
        }

        if(_currentHealt == 0)
        {
            SceneManager.LoadScene("Defeat");
        }
    }

    public void AddHealth(float amountToAdd)
    {
        if(_currentHealt == _maximumHealt)
        {
            return;
        }

        _currentHealt += amountToAdd;

        if (_currentHealt > _maximumHealt)
        {
            _currentHealt = _maximumHealt;
        }
    }
}
