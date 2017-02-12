using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private int score;
    private GUIStyle style;

	// Use this for initialization
	void Start ()
    {
        score = 0;
        style = new GUIStyle();
        style.normal.textColor = Color.white;
        style.fontSize = 16;
	}

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width - Screen.width / 8, 10, Screen.width / 8, 25), "Score: " + score, style);
    }

    public void UpdateScore(int i)
    {
        score += i;
    }
}
