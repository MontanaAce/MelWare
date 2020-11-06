using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    PlayerHealth playerHealth;
    public int healthAdd = 5;


    void OnEnable()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(playerHealth.health < playerHealth.maxHealth)
        {
            Destroy(gameObject);
            playerHealth.health += healthAdd;
            if(playerHealth.health > playerHealth.maxHealth)
            {
                playerHealth.health = playerHealth.maxHealth;
            }
            playerHealth.UpdateText();
        }
    }
}
