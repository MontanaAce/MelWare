using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject boss;
    private void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boss.gameObject.SetActive(true);
        }
    }
}
