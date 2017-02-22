using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject controlWindow;


	public void StartClick ()
    {
        SceneManager.LoadScene("Scene 1");
    }

    public void ControlsClick()
    {
        controlWindow.SetActive(true);
    }

    public void CloseClick ()
    {
        controlWindow.SetActive(false);
    }

    public void ExitClick()
    {
        Application.Quit();
    }
}
