using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainScreen;
    public GameObject credScreen;

    private void Start()
    {
        mainScreen.SetActive(true);
        credScreen.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("ARG HUB");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ToCredits()
    {
        mainScreen.SetActive(false);
        credScreen.SetActive(true);
    }

    public void Back()
    {
        mainScreen.SetActive(true);
        credScreen.SetActive(false);
    }
}
