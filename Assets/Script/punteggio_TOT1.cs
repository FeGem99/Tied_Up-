using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int punteggio = score_progress.score;
            SceneManager.LoadScene("risultati_1", LoadSceneMode.Single);
        }
    }
}