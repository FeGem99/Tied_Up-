using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheletrini : MonoBehaviour
{
    public float velocita = 3f;
    public float distanzaMassima = 5f;
    public Animator animator;

    private Vector3 posizioneIniziale;
    private int direzione = 1;

    private void Start()
    {
        posizioneIniziale = transform.position;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            Zelena_Movement zelenaMovement = collision.gameObject.GetComponent<Zelena_Movement>();
            if (zelenaMovement != null)
            {
                zelenaMovement.TakeDamage(1);
            }
        }
}
}