using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{

    Transform target;
    Transform myTransform;

	// Use this for initialization
	void Start ()
    {
        myTransform = GetComponentInChildren<Transform> ();
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < 20f && distance > 1f)
        {
            var point = target.transform.position;
            point.y = transform.position.y;
            transform.LookAt(point);
            //myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), Const.ROTSPEED * Time.deltaTime);
            myTransform.position += myTransform.forward * Const.MOVESPEED / 4 * Time.deltaTime;
        }
        else if (distance <= 1f)
        {
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), Const.ROTSPEED * Time.deltaTime);
        }
	}
}
