using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform bulletPosition;
    [SerializeField] private GameObject[] bullets;

    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private Camera mainCamera;
    private FinishLine1 finishline1;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        finishline1 = FindObjectOfType<FinishLine1>();
    }

    private void Update()
    {
        if ((Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.K)) && cooldownTimer > attackCooldown && finishline1.canAttack)
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        cooldownTimer = 0;

        bullets[FindBullet()].transform.position = bulletPosition.position;
        bullets[FindBullet()].GetComponent<BulletMovement>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindBullet()
    {
        for(int i = 0; i < bullets.Length; i++)
        {
            if (!bullets[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
