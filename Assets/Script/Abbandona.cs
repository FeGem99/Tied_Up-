using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Abbandona : MonoBehaviour
{
    private pause pausa;

    private void Start(){
       pausa = FindObjectOfType<pause>();
    }
   public void OnMainMenuButtonClicked()
    {
        // Resettare il punteggio a 0
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

        // Caricare la scena del menu principale
        SceneManager.LoadScene("menu");
    }
}
