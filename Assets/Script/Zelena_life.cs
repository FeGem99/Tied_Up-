using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;
public class Zelena_life : MonoBehaviour
{
      private Animator anim;
    private Rigidbody2D rb;
    private score_progress score;
    public Text lifeText; // Riferimento al testo UI della vita del personaggio
    public int maxLife = 100; // Vita massima del personaggio
    private int currentLife; // Vita attuale del personaggio

    private void Start()
    {
        score = GetComponent<score_progress>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentLife = maxLife;
        UpdateLifeText();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            TakeDamage(100);
        }
    }

    private void TakeDamage(int damage)
    {
        currentLife -= damage;
        UpdateLifeText();

        if (currentLife <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");

        // Puoi aggiungere qui altre azioni quando il personaggio muore, come mostrare un pannello di Game Over, ecc.
    }

    private void UpdateLifeText()
    {
        lifeText.text = " " + currentLife.ToString();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        score.setDelay();
    }
}