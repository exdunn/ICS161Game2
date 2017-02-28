using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int curHealth = 100;

    private GameObject player;
    private GUIStyle style;
    private float healthBarLen;
    private Font myFont;

    void Awake ()
    {
        style = new GUIStyle();
        style.normal.textColor = Color.white;
        style.alignment = TextAnchor.UpperCenter;
        style.fontSize = 22;
        myFont = (Font)Resources.Load("FISH&CHIPS-Regular", typeof(Font));
        style.font = myFont;
    }

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        healthBarLen = Screen.width / 2;

	}

	// Update is called once per frame
	void Update () {
        AdjustCurHealth(0);
	}

    void OnGUI()
    {
        PlayerAttack pa = (PlayerAttack)player.GetComponent<PlayerAttack>();
        if (pa.GetTarget() == gameObject)
        {
            GUI.Label(new Rect(HealthBarPosition(healthBarLen), 10, healthBarLen, 25), gameObject.name, style);
            GUI.Box(new Rect(HealthBarPosition(healthBarLen), 30, healthBarLen, 25), curHealth + "/" + maxHealth);
        }
    } 

    private float NameLen ()
    {
        return 0f;
    }

    private float HealthBarPosition (float length)
    {
        return Screen.width / 2 - length / 2;
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
