using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    public GameObject PauseMenu, Pausebutton;

	public void pause()
    {
        PauseMenu.SetActive(true);
        Pausebutton.SetActive(false);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        Pausebutton.SetActive(true);
        Time.timeScale = 1;
    }
}
