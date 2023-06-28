using UnityEngine;
using UnityEngine.UI;

public class score_progress : MonoBehaviour
{
    public Text scoreText;
    private int score = 100000;
    private float decreaseInterval = 0.25f;
    private float decreaseDelay = 20f; // 3 minuti in secondi
    private float timer = 0f;
    private bool isDecreasing = false;
    private int decreaseAmount = 50;

    private void Update()
    {
        // Se il decremento del punteggio non è ancora iniziato
        if (!isDecreasing)
        {
            // Incrementa il timer
            timer += Time.deltaTime;

            // Se il timer supera il ritardo del decremento
            if (timer >= decreaseDelay)
            {
                // Inizia il decremento del punteggio
                isDecreasing = true;
            }
        }
        else
        {
            // Aggiorna il timer
            timer += Time.deltaTime;

            // Se il timer supera l'intervallo desiderato
            if (timer >= decreaseInterval)
            {
                // Diminuisci il punteggio
                score -= decreaseAmount;

                // Aggiorna il testo del punteggio
                scoreText.text = score.ToString();

                // Reimposta il timer
                timer = 0f;
            }
        }
    }
}