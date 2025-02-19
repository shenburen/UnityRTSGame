using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private float unitHealth;
    public float unitMaxHealth;
    public HealthTracker healthTracker;

    private void Start()
    {
        UnitSelectionManager.Instance.allUnitsList.Add(gameObject);

        unitHealth = unitMaxHealth;
        UpdateHealth();
    }

    private void OnDestroy()
    {
        UnitSelectionManager.Instance.allUnitsList.Remove(gameObject);
    }

    public void TakeDamage(int damageToInflict)
    {
        unitHealth -= damageToInflict;
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        healthTracker.UpdateSliderValue(unitHealth, unitMaxHealth);

        if (unitHealth <= 0)
        {
            // ËÀÍöÂß¼­
            Destroy(gameObject);
        }
    }
}
