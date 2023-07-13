using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheletrini : MonoBehaviour
{
    public float velocita = 3f;

    private bool isAttacking = false;
    public float distanzaMassima = 5f;
    public Animator animator;
    public int maxHealth = 40;

    private int currentHealth;

    private Vector3 posizioneIniziale;
    private int direzione = 1;
    private bool canAttack = true;
  public event System.Action<int> OnAttack;
    

    private void Start()
    {
        posizioneIniziale = transform.position;
        currentHealth = maxHealth;
        
    }

    private void Update()
    {
        float distanzaPercorsa = Mathf.Abs(transform.position.x - posizioneIniziale.x);

        if (distanzaPercorsa >= distanzaMassima)
        {
            direzione *= -1;
        }

        float spostamento = velocita * Time.deltaTime * direzione;
        transform.Translate(new Vector3(spostamento, 0f, 0f));

        if (direzione == 1)
        {
            
            animator.SetBool("run", true);
            transform.localScale = new Vector3(0.5f, 0.4f, 1f);
        }
        else
        {
            animator.SetBool("run", true);
            transform.localScale = new Vector3(-0.5f, 0.4f, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player") && canAttack)
    {
        isAttacking = true;
        animator.SetBool("touch", true);
        Zelena_Movement zelenaMovement = collision.gameObject.GetComponent<Zelena_Movement>();
        Dardust_Movement dardustMovement = collision.gameObject.GetComponent<Dardust_Movement>();
        
        if (zelenaMovement != null)
        {
            zelenaMovement.TakeDamage(1);
             OnAttack?.Invoke(15);
        }
        else if (dardustMovement != null)
        {
            dardustMovement.TakeDamage(1);
             OnAttack?.Invoke(15);
            canAttack = false; // Impedisce allo scheletrino di attaccare nuovamente
        }
    }
}
    private void OnCollisionExit2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        isAttacking = false;
        animator.SetBool("touch", false);
        canAttack = true; // Permette allo scheletrino di attaccare di nuovo
        
    }
    if(collision.gameObject.CompareTag("proiettile"))
    {
        TakeDamage(15);
    }
}
private void Die()
{
    // Logica per la sconfitta dello scheletro
    Destroy(gameObject); // Distruggi il gameObject dello scheletro
}
public void TakeDamage(int damage)
{
    currentHealth -= damage;

    if (currentHealth <= 0)
    {
        Die();
    }
}

}