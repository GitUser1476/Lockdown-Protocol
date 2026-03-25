using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maximumHealth = 100f;

    public float RemainingHealthPercentage
    {
        get
        {
            if (_maximumHealth <= 0)
            {
                return 0f;
            }

            return _currentHealth / _maximumHealth;
        }
    }

    public UnityEvent OnHealthChanged;

    private void Start()
    {
        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        if (_currentHealth > _maximumHealth)
        {
            _currentHealth = _maximumHealth;
        }

        OnHealthChanged.Invoke();
    }

    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth <= 0)
        {
            return;
        }

        _currentHealth -= damageAmount;

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        OnHealthChanged.Invoke();

        if (_currentHealth == 0)
        {
            SceneManager.LoadScene("Defeat");
        }
    }

    public void AddHealth(float amountToAdd)
    {
        if (_currentHealth >= _maximumHealth)
        {
            return;
        }

        _currentHealth += amountToAdd;

        if (_currentHealth > _maximumHealth)
        {
            _currentHealth = _maximumHealth;
        }

        OnHealthChanged.Invoke();
    }
}