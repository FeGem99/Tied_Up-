using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma_dardast : MonoBehaviour
{
    public Animator animator;

    private bool isAttacking = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Attack_D") != 0f && !isAttacking)
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    private IEnumerator AttackCoroutine()
    {
        isAttacking = true;

        animator.SetTrigger("Attacco");

        // Attendi fino a quando l'animazione di attacco è completata
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        animator.SetTrigger("RitornaNormale");

        isAttacking = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Nemico") && isAttacking)
        {
            Sheletrini sheletrini = collision.gameObject.GetComponent<Sheletrini>();
            if (sheletrini != null)
            {
                sheletrini.TakeDamage(1);
            }
        }
    }
}
