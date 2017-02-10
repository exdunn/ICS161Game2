using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour {

    GameObject staff;

	// Use this for initialization
	void Awake () {
        staff = transform.Find("Player/Staff").gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown ("Fire1"))
        {
            staff.GetComponent<Animator>().SetTrigger("Swing");
        }	
	}
}
