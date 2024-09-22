using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float bulletSpeed = 15f;
    public float bulletDamage = 10f;
    public Rigidbody2D rb;
    
 
    public void FixedUpdate()
    {
        rb.velocity = transform.right * bulletSpeed;
    }
 
    void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
        Destroy(gameObject);
    }
}
