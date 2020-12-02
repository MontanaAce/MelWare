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
    public bool isAttacking;
    //private float timeBtwDamage = 1.5f;
    public Text healthText;
    public Transform startRollPos;
    public Transform endRollPos;

    public Animator anim;
    private void OnEnable()
    {
        healthText = GameObject.Find("PangText").GetComponent<Text>();
        healthText.text = health + "/" + maxHealth;
        anim = GetComponent<Animator>();
        anim.SetTrigger("Introduction");
        StartCoroutine(Introduction());
    }

    private void Update()
    {
        if (health != int.Parse(healthText.text.ToString().Split('/')[0]))
        {
            UpdateText();
        }
        if (health <= 0)
        {
            anim.SetBool("IsDead", true);
            StartCoroutine(BossDeath());
        }
        if(isAttacking == false)
        {
            i = Random.Range(1, 21);
            if (i == 1 || i == 2 || i == 3 || i == 4 || i == 5)
            {
                isAttacking = true;
                anim.SetBool("Idling", false);
                anim.SetBool("Rolling", false);
                anim.SetBool("Flipping", false);
                anim.SetBool("Slashing", true);
                StartCoroutine(WaitForAnim());
            }
            else if (i == 6 || i == 7 || i == 8 || i == 9 || i == 10)
            {
                isAttacking = true;
                anim.SetBool("Slashing", false);
                anim.SetBool("Rolling", false);
                anim.SetBool("Flipping", false);
                anim.SetBool("Idling", true);
                StartCoroutine(WaitForAnim());
            }
            else if (i == 11 || i == 12 || i == 13 || i == 14 || i == 15)
            {
                isAttacking = true;
                anim.SetBool("Slashing", false);
                anim.SetBool("Rolling", false);
                anim.SetBool("Idling", false);
                anim.SetBool("Flipping", true);
                StartCoroutine(WaitForAnim());
            }
            else if (i == 16 || i == 17 || i == 18 || i == 19 || i == 20)
            {
                isAttacking = true;
                anim.SetBool("Slashing", false);
                anim.SetBool("Idling", false);
                anim.SetBool("Flipping", false);
                anim.SetBool("Rolling", true);
                //StartCoroutine(WaitForAnim());
                StartCoroutine(Rolling());
            }
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
        isAttacking = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerAllinOne>().TakeDamage(damage);
        }
    }
    public IEnumerator BossDeath()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    IEnumerator Introduction()
    {
        yield return new WaitForSeconds(3);
    }
    public IEnumerator Rolling()
    {
        float firstDuration = 1;
        float secondDuration = 1.5f;
        float t = 0;
        Vector3 currentPos = transform.position;
        while(t < firstDuration)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(currentPos, startRollPos.position, t / firstDuration);
            yield return null;
        }
        t = 0;
        currentPos = transform.position;
        while (t < secondDuration)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(currentPos, endRollPos.position, t / secondDuration);
            yield return null;
        }
        t = 0;
        currentPos = transform.position;
        while (t < secondDuration)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(currentPos, startRollPos.position, t / secondDuration);
            yield return null;
        }
        isAttacking = false;
    }
}
