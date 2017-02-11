using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private float movespeed = 1.5f;
    private Transform target;
    private Transform myTransform;
    private float maxDistance;

    void Awake ()
    {
        myTransform = transform;
    }

	// Use this for initialization
	void Start ()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
        maxDistance = 2.0f;
	}

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(target.transform.position, myTransform.position, Color.yellow);
        float distance = Vector3.Distance(target.transform.position, transform.position);

        // Look at target
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(
            target.position - myTransform.position), (Const.ROTSPEED / 2) * Time.deltaTime);

        // move towards target
        if (distance > maxDistance)
        { 
            myTransform.position += myTransform.forward * movespeed * Time.deltaTime;
        }
	}
}
