using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private HealthSystem healthSystem;
    private string healthBarName;
    private GameObject entity;

    public void Setup(HealthSystem healthSystem, string healthBarName, GameObject entity)
    {
        this.healthSystem = healthSystem;
        this.healthBarName = healthBarName;
        this.entity = entity;
        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
    }

    private void HealthSystem_OnHealthChanged(object sender, System.EventArgs e)
    {
        transform.Find(healthBarName).localScale = new Vector3(healthSystem.GetHealthPercent(), 1);
        if (healthSystem.GetHealth() ==0)
        {
            Destroy(entity);
        }
    }
}
