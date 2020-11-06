using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeProjectile : MonoBehaviour
{
    //Initial speed of the grenade, in the direction of the cursor.
    public float speed;
    //Max damage taken, if at the point of contact.
    public int damage;

    public float distance;
    public LayerMask whatIsSolid;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.right, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            DestroyProjectile();
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void DestroyProjectile()
    {
        //ObjectPool.Spawn(destroyEffect, transform.position, Quaternion.identity);
        //ObjectPool.Despawn(gameObject);
    }
}
