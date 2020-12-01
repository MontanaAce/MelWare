using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGrenade : MonoBehaviour
{
    public Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        weapon = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        weapon.hasgrenade = true;
        Destroy(gameObject);
    }
}
