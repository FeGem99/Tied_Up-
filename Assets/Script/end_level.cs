using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class end_level : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("sbarra"))
        {
            // Ottieni tutti gli oggetti con il tag "sbarra"
            GameObject[] sbarre = GameObject.FindGameObjectsWithTag("sbarra");

            // Rimuovi gli oggetti con il tag "sbarra"
            foreach (GameObject sbarra in sbarre)
            {
                Destroy(sbarra);
            }
        }
    }
}
