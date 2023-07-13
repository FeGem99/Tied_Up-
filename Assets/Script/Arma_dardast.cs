using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma_dardast : MonoBehaviour
{
    private bool isAttacking = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("nemico") && isAttacking)
        {
            // Cambia il tag del personaggio in "attaccante"
            gameObject.tag = "attaccante";

            // Infliggi danno al nemico
            Sheletrini sheletrini = collision.gameObject.GetComponent<Sheletrini>();
            if (sheletrini != null)
            {
                sheletrini.TakeDamage(3);
            }
        }
    }

    private void Update()
    {
        // Controlla se il tasto S è stato premuto per attaccare
        if (Input.GetKeyDown(KeyCode.S) && !isAttacking)
        {
            isAttacking = true;

            // Avvia l'animazione di attacco
            animator.SetTrigger("Attacco");
        }

        // Controlla se il tasto S è stato rilasciato per tornare allo stato normale
        if (Input.GetKeyUp(KeyCode.S) && isAttacking)
        {
            isAttacking = false;
            animator.SetTrigger("RitornaNormale");
        }
    }
}
