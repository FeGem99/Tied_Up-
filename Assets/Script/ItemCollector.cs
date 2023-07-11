using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text GemsText;
    [SerializeField] private Text LifeText; // Testo UI che rappresenta la vita del personaggio
    public int gemme = 0;
    public int gemmeTotali = 0;
    public int maxLife = 100;
    private int currentLife;
    private int up = 15;
    public GameObject personaggio1; // Riferimento al primo personaggio
    public GameObject personaggio2; // Riferimento al secondo personaggio

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemCollector personaggio1Collector = personaggio1.GetComponent<ItemCollector>();
        ItemCollector personaggio2Collector = personaggio2.GetComponent<ItemCollector>();

        if (collision.gameObject.CompareTag("Gems"))
        {
            Destroy(collision.gameObject);
            gemme++;
            gemmeTotali = personaggio1Collector.gemme + personaggio2Collector.gemme;
            GemsText.text = "Gemme: " + gemmeTotali;

            // Aggiungi logica per aumentare la vita del personaggio
            
           

            if (currentLife < maxLife)
            {
                currentLife += up;
                currentLife = Mathf.Clamp(currentLife, 0, maxLife); // Assicurati che la vita non superi il valore massimo

                // Aggiorna il testo UI della vita del personaggio
                LifeText.text = " " + up.ToString();
            }

            // Aggiungi logica per la fine del livello
            if (gemmeTotali == 3)
            {
                GameObject[] sbarre = GameObject.FindGameObjectsWithTag("sbarra");

                // Rimuovi gli oggetti con il tag "sbarra"
                foreach (GameObject sbarra in sbarre)
                {
                    Destroy(sbarra);
                }
            }
        }
    }
}