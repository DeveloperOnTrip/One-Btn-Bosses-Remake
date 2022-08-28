using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject target;
    public float bulletSpeed;
    public float bulletLifeTime = 3;

    public float bulletDamage = 2;

    BossHealth bossHealth;

    public GameObject lockal;

    private void Awake()
    {
        lockal = GameObject.FindGameObjectWithTag("Locakl");

        target = GameObject.FindGameObjectWithTag("Boss");
        bossHealth = FindObjectOfType<BossHealth>();
    }

    void Update()
    {
        transform.SetParent(lockal.transform);

        Vector2 moveDirection =(target.transform.position - transform.position).normalized * bulletSpeed;
        rb.velocity = new Vector2(moveDirection.x,moveDirection.y);
        Destroy(this.gameObject,bulletLifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            bossHealth.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
