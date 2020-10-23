﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryPlayerAttack : MonoBehaviour
{
    public float attackSpeed = 5.5f;
    private Rigidbody2D pa;
    private Transform player;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        pa = this.GetComponent<Rigidbody2D>();
        pa.velocity = new Vector2(attackSpeed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(screenBounds.x, screenBounds.y, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > screenBounds.x * -1)
        {
            Destroy(this.gameObject);
        }
        else if (transform.position.x < screenBounds.x)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        if (other.CompareTag("room"))
        {
            Destroy(this.gameObject);
        }
    }
}
