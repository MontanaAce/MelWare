using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public GameObject deathEffect;
    public Text healthText;

    private void Start()
    {
        healthText.text = health + "/" + maxHealth;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateText();
    }
    private void UpdateText()
    {
        healthText.text = health + "/" + maxHealth;
    }

}
