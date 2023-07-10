using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma_dardast : MonoBehaviour
{

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Attack();
        }
    }

    private void Attack()
    {
        // Avvia l'animazione di attacco
        animator.SetTrigger("Dardust_Attacco");
    }

}
