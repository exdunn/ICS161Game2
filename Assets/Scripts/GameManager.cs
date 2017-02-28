using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private int score;
    private GUIStyle style;
    private GUIStyle scoreStyle;
    private GameObject player;
    private bool menuOpen;
    private Font myFont;

    public GameObject escMenu;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        menuOpen = false;

        Time.timeScale = 1f;
        score = 0;

        myFont = (Font)Resources.Load("FISH&CHIPS-Regular", typeof(Font));
        style = new GUIStyle();
        style.normal.textColor = Color.white;
        style.font = myFont;
        style.fontSize = 30;
        scoreStyle = style;
        scoreStyle.fontSize = 38;
	}

    void Update ()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuOpen)
            {
                menuOpen = false;
                escMenu.SetActive(false);
            }
            else
            {
                menuOpen = true;
                escMenu.SetActive(true);
            }
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width - Screen.width / 8, 10, Screen.width / 8, 25), "Score: " + score, style);

        if (HealthIsZero())
        {
            string message = "YOU HAVE DIED PRESS ESC TO OPEN MENU";
            GUI.Label(new Rect(Screen.width / 2 - Screen.width / 8, Screen.height - 50, Screen.width / 8, 25), message, style);
            Time.timeScale = 0;
        }
    }
    
    // increment player score
    public void UpdateScore(int i)
    {
        score += i;
    }

    // get current score
    public int GetScore ()
    {
        return score;
    }

    // return true if player health reaches 0
    private bool HealthIsZero ()
    {
        return player.GetComponent<PlayerHealth>().curHealth == 0 ? true : false;
    }

    // go to main menu scene
    public void MainMenuClick ()
    {
        SceneManager.LoadScene("Main Menu");
    }

    // restart scene
    public void RestartLevel ()
    {
        SceneManager.LoadScene("Scene 1");
    }
}
