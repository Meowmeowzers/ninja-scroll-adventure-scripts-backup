using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Stats : MonoBehaviour
{
    [SerializeField] float currentHealth = 0f;
    [SerializeField] float startingHealth = 10f;
    [SerializeField] float maxHealth = 10f;
    [SerializeField] float _baseDamage = 2f;
    [SerializeField] bool isDead = false;
    public event Action<float> HealthChanged;

	void Awake()
	{
        currentHealth = startingHealth;
        if(startingHealth > maxHealth) currentHealth = maxHealth;
	}

    public void RestoreHealth(float amount){
        if(isDead) return;

        currentHealth += amount;

        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
        HealthChanged?.Invoke(currentHealth);
    }
    public void DamageHealth(float amount){
        if(isDead) return;

        currentHealth -= amount;

        if(currentHealth < 1f){
            isDead = true;
        }
        HealthChanged?.Invoke(currentHealth);
    }

    public float GetHealth(){
        return currentHealth;
    }

}
