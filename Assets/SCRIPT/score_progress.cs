using System;
using UnityEngine;
using UnityEngine.UI;


public class score_progress : MonoBehaviour
{
    public static int score = 100000;
    public Text scoreText;
    private float decreaseInterval = 1f;
    private float decreaseDelay = 30f; 
    private float timer = 0f;
    private bool isDecreasing = false;
    private int decreaseAmount = 250;
    private bool isCounting = true;
  //  private bool isSceneRestarted = false;

   

    private void Start()
    {

      // Verifica se la scena è stata riavviata
        if (PlayerPrefs.HasKey("IsSceneRestarted") && PlayerPrefs.GetInt("IsSceneRestarted") == 1)
        {
            setDelay();
            PlayerPrefs.SetInt("IsSceneRestarted", 0);
        }

        // Aggiorna il testo del punteggio
        scoreText.text = score.ToString(); 
         }

    public void setDelay()
    {
        decreaseDelay = 0f;
    }

    private void Update()
    {
        // Verifica se si è nel processo di respawning
        //bool isCounting = false; /* Aggiungi qui la tua logica per verificare il respawning */;

        // Se non si è nel processo di respawning, diminuisci il punteggio
        if (!isCounting)
        return;
        {
            // Aggiorna il timer
            timer += Time.deltaTime;

            // Se il decremento del punteggio non è ancora iniziato
            if (!isDecreasing)
            {
                // Se il timer supera il ritardo del decremento
                if (timer >= decreaseDelay)
                {
                    // Inizia il decremento del punteggio
                    isDecreasing = true;
                }
            }
            else
            {
                // Se il timer supera l'intervallo desiderato
                if (timer >= decreaseInterval)
                {
                    // Diminuisci il punteggio
                    score_progress.score -= decreaseAmount;

                    // Aggiorna il testo del punteggio
                    scoreText.text = score_progress.score.ToString();

                    // Reimposta il timer
                    timer = 0f;
                }
            }
        }
    }

    public void StopScoreCounting(){
        isCounting = false;
    }
    public static void SetSceneRestarted()
    {
        PlayerPrefs.SetInt("IsSceneRestarted", 1);
    }
}