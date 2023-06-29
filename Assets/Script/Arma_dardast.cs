using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma_dardast : MonoBehaviour
{

    private Animator animator;
    private bool isAttacking = false;

    // Riferimento all'oggetto spada attaccato al personaggio
    public GameObject sword;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && !isAttacking)
        {
            Attack();
        }
    }

    private void Attack()
    {
        // Imposta lo stato di attacco su true
        isAttacking = true;

        // Avvia l'animazione di attacco
        animator.SetTrigger("Attack");

        // Disabilita la collisione della spada con il personaggio
        sword.GetComponent<Collider2D>().enabled = false;

        // Abilita la collisione della spada dopo un breve ritardo
        Invoke("EnableSwordCollision", 0.2f);

        // Imposta lo stato di attacco su false dopo un periodo di tempo
        Invoke("FinishAttack", 0.5f);
    }

    private void EnableSwordCollision()
    {
        // Abilita la collisione della spada
        sword.GetComponent<Collider2D>().enabled = true;
    }

    private void FinishAttack()
    {
        // Imposta lo stato di attacco su false
        isAttacking = false;
    }
}
