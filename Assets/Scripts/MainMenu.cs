﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void StartClick ()
    {
        SceneManager.LoadScene("Scene 1");
    }

    public void ControlsClick()
    {

    }

    public void ExitClick()
    {
        Application.Quit();
    }
}
