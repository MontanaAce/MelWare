using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float offset;


    public GameObject muzzFlash;
    public GameObject mainProjectile;
    public GameObject grenadeProjectile;
    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public bool hasgrenade = false;

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ObjectPool.Spawn(muzzFlash, shotPoint.position, transform.rotation);
                Instantiate(mainProjectile, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
            if (hasgrenade && Input.GetMouseButtonDown(1))
            {
                ObjectPool.Spawn(muzzFlash, shotPoint.position, transform.rotation);
                Instantiate(grenadeProjectile, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
            
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
