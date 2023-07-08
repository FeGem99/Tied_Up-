using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pausePanel;
    

    void Update()
    {
        if ( Input.GetButtonDown("Pausa"))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
       isPaused = !isPaused;
    if (isPaused)
    {
        Time.timeScale = 0f; // Ferma il tempo di gioco
        pausePanel.SetActive(true); // Mostra il pannello di pausa
    }
    else
    {
        Time.timeScale = 1f; // Ripristina il tempo di gioco normale
        pausePanel.SetActive(false); // Nascondi il pannello di pausa
    }
    }
}
