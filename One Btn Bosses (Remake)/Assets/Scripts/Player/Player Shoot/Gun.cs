using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Tooltip("Where the bullet Instantiate")] public Transform shootPoint;
    
    [Header("Bullets Prefabs")]
    public GameObject bulletPrefabZero;
    public GameObject bulletPrefabOne;
    public GameObject bulletPrefabTwo;

    [Header("Bullet Times")]
    public float bulletTimeZero;
    public float bulletTimeOne;
    public float bulletTimeTwo;
    float bulletTimer = 10;//Bullet Timer

    [Header("Gun Options")]
    [Tooltip("How fast the gun will shoot")][Range(0.1f,2)] public float fireRate;
    float nextFireTime;


    private void Update()
    {
        bulletTimer += Time.deltaTime;
        if(bulletTimer <=0)
            bulletTimer = 0;

        if (nextFireTime < Time.time)
        {
            nextFireTime = Time.time + fireRate;

            if(bulletTimer > bulletTimeZero && bulletTimer < bulletTimeOne)
                Instantiate(bulletPrefabZero, shootPoint);
            if(bulletTimer > bulletTimeOne && bulletTimer < bulletTimeTwo)
                Instantiate(bulletPrefabOne, shootPoint);
            if(bulletTimer > bulletTimeTwo)
                Instantiate(bulletPrefabTwo, shootPoint);
        }

        if(Input.GetKeyDown(KeyCode.Space))
            bulletTimer = 0;
    }
}
