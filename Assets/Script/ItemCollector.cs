using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text GemsText;
    public int gemme = 0;
    public int gemmeTotali = 0;
    public GameObject personaggio1; // Riferimento al primo personaggio
    public GameObject personaggio2; // Riferimento al secondo personag
    private void OnTriggerEnter2D (Collider2D collision)
    {
        ItemCollector personaggio1Collector = personaggio1.GetComponent<ItemCollector>();

            // Ottieni il componente ItemCollector dal secondo personaggio
            ItemCollector personaggio2Collector = personaggio2.GetComponent<ItemCollector>();

            // Somma le gemme raccolte da entrambi i personaggi
            //int gemmeTotali = personaggio1Collector.gemme + personaggio2Collector.gemme;
        if(collision.gameObject.CompareTag("Gems")){
            Destroy(collision.gameObject);
            gemme++;
        
             gemmeTotali = personaggio1Collector.gemme + personaggio2Collector.gemme;
            GemsText.text = "Gemme: " +gemmeTotali;

            //aggiunta logica della fine del livello
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