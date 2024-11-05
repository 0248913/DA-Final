using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;  
    private int currentHealth;   

   
    void Start()
    {
        
        currentHealth = maxHealth;
    }

    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; 

        
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log("Player took " + damage + " damage. Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

   
    public void Heal(int healAmount)
    {
        currentHealth += healAmount; 

        
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log("Player healed by " + healAmount + ". Current health: " + currentHealth);
    }

  
    void Die()
    {
        Debug.Log("Player has died.");
       
    }
}
