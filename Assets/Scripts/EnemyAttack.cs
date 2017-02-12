using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    
    private GameObject target;
    private float attackTimer;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        attackTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        if (attackTimer < 0)
        {
            attackTimer = 0;
        }

        if (attackTimer == 0)
        {
            Attack();
            attackTimer = Const.COOLDOWN;
        }
    }

    private void Attack()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);

        Vector3 dir = (target.transform.position - transform.position).normalized;
        float direction = Vector3.Dot(dir, transform.forward);

        if (distance < 3.5f && direction > 0.6f)
        {
            PlayerHealth ph = (PlayerHealth)target.GetComponent("PlayerHealth");
            ph.AdjustCurHealth(-10);
        }
    }
}
