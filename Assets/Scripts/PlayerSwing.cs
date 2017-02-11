using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour {

    private GameObject staff;
    private GameObject target;
    private float attackTimer;

	void Awake ()
    {    
        staff = transform.Find("Staff").gameObject;
	}

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("enemy");
    }

    // Update is called once per frame
	void Update ()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        if (attackTimer < 0)
        {
            attackTimer = 0;
        }

        if (attackTimer == 0 && Input.GetButtonDown ("Fire1"))
        {
            staff.GetComponent<Animator>().SetTrigger("Swing");
            Attack();
            attackTimer = Const.COOLDOWN;
        }	
	}

    private void Attack()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);

        Vector3 dir = (target.transform.position - transform.position).normalized;
        float direction = Vector3.Dot(dir, transform.forward);

        Debug.Log(direction);
        if (distance < 2.5f && direction > 0.6f)
        {
            EnemyHealth eh = (EnemyHealth)target.GetComponent("EnemyHealth");
            eh.AdjustCurHealth(-10);
        }
    }
}
