using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    private pause pausa;

    private void Start(){
       pausa = FindObjectOfType<pause>();
    }
    public void OnRestartButtonClicked()
    {
        // Resettare il punteggio a 100000
        score_progress scoreProgress = FindObjectOfType<score_progress>();
        if (scoreProgress != null)
        {
            score_progress.score = 100000;
        }
         // Uscire dallo stato di pausa
        if (pausa != null)
        {
            pausa.TogglePause();
        }

        // Ricominciare il gioco ricaricando la scena corrente
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
