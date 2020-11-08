using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCheck : MonoBehaviour
{
    //Takes the available tags and allows you to select them in the inpector
    //without having to spell them directly.
    [TagSelector]
    public string[] TagFilterArray = new string[] { };
    //Damage taken at the point of contact
    [SerializeField] float maxDamage;
    //The box collider representing the damage area of the grenade
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] Vector2 enemyRelative;

    [SerializeField] float explosionForce;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (string tag in TagFilterArray)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                Debug.Log("Hit enemy!");
                enemyRelative = transform.position 
                    - collision.transform.position;
                float enemyDistance = Mathf.Abs(enemyRelative.magnitude);
                Debug.Log(enemyRelative.ToString() + "\n" + enemyDistance);
                float netDamage = maxDamage;
                if(netDamage > 0)
                {
                    collision.GetComponent<Enemy>().
                        TakeDamage(Mathf.RoundToInt(netDamage));
                    collision.attachedRigidbody.
                        AddForce(enemyRelative * explosionForce);
                }
            }
        }
    }
}
