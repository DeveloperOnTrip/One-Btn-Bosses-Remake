using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Tooltip("Where the bullet Instantiate")] public Transform shootPoint;

    public GameObject bulletPrefabZero;
    public GameObject bulletPrefabOne;
    public GameObject bulletPrefabTwo;

    public float bulletTimeZero;
    public float bulletTimeOne;
    public float bulletTimeTwo;

    public float fireRate;
    float nextFireTime;

    [SerializeField] float nextBullet = 10;

    private void Update()
    {
        nextBullet += Time.deltaTime;
        if(nextBullet <=0)
            nextBullet = 0;

        if (nextFireTime < Time.time)
        {
            nextFireTime = Time.time + fireRate;

            if(nextBullet > bulletTimeZero && nextBullet < bulletTimeOne)
                Instantiate(bulletPrefabZero, shootPoint);
            if(nextBullet > bulletTimeOne && nextBullet < bulletTimeTwo)
                Instantiate(bulletPrefabOne, shootPoint);
            if(nextBullet > bulletTimeTwo)
                Instantiate(bulletPrefabTwo, shootPoint);
        }

        if(Input.GetKeyDown(KeyCode.Space))
            nextBullet = 0;
    }
}
