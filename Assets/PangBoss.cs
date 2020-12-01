using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PangBoss : MonoBehaviour
{
    public int health;
    public int damage;
    private float timeBtwDamage = 1.5f;

    public Animator anim;
    public Slider healthBar;


    private void Update()
    {
        if(timeBtwDamage > 0)
        {
            timeBtwDamage -= Time.deltaTime;
        }

        healthBar.value = health;
    }
}
