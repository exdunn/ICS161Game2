﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour {

    public GameObject staff;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown ("Fire1"))
        {

            Debug.Log("swing!");
            staff.GetComponent<Animator>().SetTrigger("Swing");
        }	
	}
}
