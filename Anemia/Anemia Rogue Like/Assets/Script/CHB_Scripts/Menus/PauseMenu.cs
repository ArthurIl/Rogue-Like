using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;
    private bool pauseToggled = false;
    void Start()
    {
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            TogglePause();
        }

        //Debug.Log("TimeScale: " + Time.timeScale);
        
    }

    public void TogglePause()
    {
        if (!pauseToggled)
        {
            pauseToggled = true;
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
        }
        else
        {
            Resume();
        }
    }

    public void Resume()
    {
        pauseScreen.SetActive(false);
        pauseToggled = false;
        Time.timeScale = 1f;
    }

    public void ToHub()
    {
        SceneManager.LoadScene("ARG HUB");
        Time.timeScale = 1f;
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("CHB_MainMenu");
        Time.timeScale = 1f;
    }
}
