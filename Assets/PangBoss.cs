using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PangBoss : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int damage;
    private int i;
    public float animDur = 1;
    public GameObject deathEffect;
    //private float timeBtwDamage = 1.5f;
    public Text healthText;

    public Animator anim;
    private void Start()
    {
        healthText = GameObject.Find("PangText").GetComponent<Text>();
        healthText.text = health + "/" + maxHealth;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (health != int.Parse(healthText.text.ToString().Split('/')[0]))
        {
            UpdateText();
        }
        if (health <= 0)
        {
            ObjectPool.Spawn(deathEffect, transform.position, Quaternion.identity);
        }
        i = Random.Range(1, 21);
        if(i == 1 || i == 2 || i == 3 || i == 4 || i == 5)
        {
            anim.SetBool("Idling", false);
            anim.SetBool("Rolling", false);
            anim.SetBool("Flipping", false);
            anim.SetBool("Slashing", true);
            StartCoroutine(WaitForAnim());
        }
        else if(i == 6 || i == 7 || i == 8 || i == 9 || i == 10)
        {
            anim.SetBool("Slashing", false);
            anim.SetBool("Rolling", false);
            anim.SetBool("Flipping", false);
            anim.SetBool("Idling", true);
            StartCoroutine(WaitForAnim());
        }
        else if(i == 11 || i == 12 || i == 13 || i == 14 || i == 15)
        {
            anim.SetBool("Slashing", false);
            anim.SetBool("Rolling", false);
            anim.SetBool("Idling", false);
            anim.SetBool("Flipping", true);
            StartCoroutine(WaitForAnim());
        }
        else if(i == 16 || i == 17 || i == 18 || i == 19 || i == 20)
        {
            anim.SetBool("Slashing", false);
            anim.SetBool("Idling", false);
            anim.SetBool("Flipping", false);
            anim.SetBool("Rolling", true);
            StartCoroutine(WaitForAnim());
        }
    }
    public void UpdateText()
    {
        healthText.text = health + "/" + maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    public IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(animDur);
    }
}
