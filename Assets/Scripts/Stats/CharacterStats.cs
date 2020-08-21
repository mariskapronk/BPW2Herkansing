﻿using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; } //any other class will get this value, but will only be set here
    
    public Stat damage;
    public Stat armor;

    void Awake ()
    {
        currentHealth = maxHealth;
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage (int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue); //damage wont go under 0

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage."); //damage calculation

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die ()
    {
        //Die in some way
        Debug.Log(transform.name + " died.");
    }
}
