using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float firingRate = 0.2f;
    
    float TimeUntilFire;
    PlayerMovement pm;
 
    private void Start()
    {
        pm = gameObject.GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && TimeUntilFire < Time.time)
        {
            Attack();
            TimeUntilFire = Time.time + firingRate;
        }
        
    }

    private void Attack()
    {
        float angle = pm.isFacingRight ? 0f : 180f;
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }
}
