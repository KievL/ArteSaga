using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseUI;
    public GameObject pauseButton;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pausar()
    {
        pauseButton.SetActive(false);
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Resumir()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseUI.SetActive(false);
        pauseButton.SetActive(true);

    }
    public void voltarMuseu()
    {

    }
    public void sairdoJogo()
    {
        PlayerPrefs.Save();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        //Application.Quit();
    }
}
