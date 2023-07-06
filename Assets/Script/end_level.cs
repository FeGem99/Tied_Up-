using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end_level : MonoBehaviour
{
    private score_progress score;
    private void start(){
        score = GetComponent<score_progress>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("sbarra"))
        {
            // Verifica se il personaggio ha raccolto tutte e tre le gemme
            ItemCollector itemCollector = collision.gameObject.GetComponent<ItemCollector>();
            if (itemCollector != null && itemCollector.gemmeTotali == 3)
            {
                // Ottieni tutti gli oggetti con il tag "sbarra"
                GameObject[] sbarre = GameObject.FindGameObjectsWithTag("sbarra");

                // Rimuovi gli oggetti con il tag "sbarra"
                foreach (GameObject sbarra in sbarre)
                {
                    Destroy(sbarra);
                    score.StopScoreCounting();
                }
                
            }
        }
    }
}