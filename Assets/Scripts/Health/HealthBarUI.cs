using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Image _healthBarForegroundImage;
    [SerializeField] private HealthController _healthController;

    public void UpdateHealthBar()
    {
        if (_healthBarForegroundImage == null || _healthController == null)
        {
            return;
        }

        _healthBarForegroundImage.fillAmount = _healthController.RemainingHealthPercentage;
    }

    private void Start()
    {
        UpdateHealthBar();
    }
    public void Update()
    {
        UpdateHealthBar();
    }
}
