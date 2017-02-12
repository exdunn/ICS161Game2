using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // when enemy dies
        // remove from player's Targeting.targets
        // add score to Game Manager
        if (HealthIsZero())
        {
            Targeting t = GameObject.FindGameObjectWithTag("Player").GetComponent<Targeting>();
            t.RemoveTarget(transform);
            GameManager gm = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
            gm.UpdateScore(1);
            Destroy(gameObject);
        }
	}

    // return true if enemy health reaches 0
    private bool HealthIsZero ()
    {
        return GetComponent<EnemyHealth>().curHealth == 0 ? true : false;
    }
}