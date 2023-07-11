using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;
public class Dardust_life : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private score_progress score;
    public Text lifeText; // Riferimento al testo UI della vita del personaggio
    public int maxLife = 100; // Vita massima del personaggio
    private int currentLife; // Vita attuale del personaggio

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        score = GetComponent<score_progress>();
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
        anim.SetTrigger("Death_D");
    }
    private void UpdateLifeText()
    {
        lifeText.text = " " + currentLife.ToString();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
