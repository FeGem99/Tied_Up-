using UnityEngine;
using UnityEngine.UI;

public class score_progress : MonoBehaviour
{
    private static int score;
    public Text scoreText;
    private float decreaseInterval = 1.5f;
    private float decreaseDelay = 10f; // 3 minuti in secondi
    private float timer = 0f;
    private bool isDecreasing = false;
    private int decreaseAmount = 5;

    private void Start()
    {
        // Imposta il punteggio iniziale
        score_progress.score = 100000;
    }

    private void Update()
    {
        // Verifica se si è nel processo di respawning
        bool isRespawning = false; /* Aggiungi qui la tua logica per verificare il respawning */;

        // Se non si è nel processo di respawning, diminuisci il punteggio
        if (!isRespawning)
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
}