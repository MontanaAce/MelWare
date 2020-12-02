using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : MonoBehaviour
{
    public float health;
    private void Update()
    {
        if( health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
