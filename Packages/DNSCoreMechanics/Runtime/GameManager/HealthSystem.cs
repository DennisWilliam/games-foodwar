using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem 
{
    public event EventHandler OnHealthChanged;
    private int health;
    private int healthMax;

    public HealthSystem(int healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;
    }

    public int GetHealth()
    {
        return health;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        if (health < 0)
        {
            health = 0;
        }
        if (OnHealthChanged != null)
        {
            OnHealthChanged(this, EventArgs.Empty);
        }
    }

    public float GetHealthPercent()
    {
        return (float) health / healthMax;
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > healthMax)
        {
            health = healthMax;
        }
        if (OnHealthChanged != null)
        {
            OnHealthChanged(this, EventArgs.Empty);
        }
    }
}
