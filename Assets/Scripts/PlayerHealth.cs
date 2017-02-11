using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int curHealth = 100;

    private float healthBarLen;

	// Use this for initialization
	void Start () {
        healthBarLen = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () {
        AdjustCurHealth(0);
	}

    void OnGUI()
    {
        GUI.Box (new Rect (10, 10, healthBarLen, 25), curHealth + "/" + maxHealth);
    } 

    public void AdjustCurHealth (int adj)
    {
        curHealth += adj;
        if (curHealth < 0)
        {
            curHealth = 0;
        }
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if (maxHealth < 1)
        {
            maxHealth = 1;
        }

        healthBarLen = (Screen.width / 2) * (curHealth / (float) maxHealth);
    }
}
