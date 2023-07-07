using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Beaviour_skeleton : MonoBehaviour
{
    public float speed = 2f; // Velocità di movimento del nemico
    public float attackRange = 2f; // Distanza a cui il nemico inizia ad attaccare il personaggio principale
    public float attackSpeed = 5f; // Velocità di movimento del nemico durante l'attacco
    public float attackDuration = 2f; // Durata dell'attacco in secondi
    public float attackCooldown = 3f; // Tempo di recupero tra gli attacchi in secondi

    private Transform target; // Riferimento al personaggio principale
    private bool isAttacking = false; // Indica se il nemico sta attaccando
    private bool isMovingRight = true; // Indica la direzione del movimento
    private float dirX = 0f;
    private float attackTimer = 0f; // Timer per l'attacco
    private float cooldownTimer = 0f; // Timer per il tempo di recupero tra gli attacchi
    private Animator anim; 
    private SpriteRenderer sprite;
    private void Start()
    {
        // Trova il riferimento al personaggio principale
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (!isAttacking)
        {
            // Muovi il nemico avanti e indietro
            Move();
            UpdateAnimation();

            // Controlla se il personaggio principale è abbastanza vicino per attaccare
            CheckAttackRange();
        }
        else
        {
            // Il nemico sta attaccando, controlla la durata dell'attacco
            AttackTimer();
        }

        // Controlla il tempo di recupero tra gli attacchi
        CooldownTimer();
    }

    private void Move()
    {
        // Calcola la direzione di movimento
        Vector2 direction = isMovingRight ? Vector2.right : Vector2.left;

        // Calcola la velocità di movimento
        Vector2 velocity = direction * speed * Time.deltaTime;

        // Applica il movimento
        transform.Translate(velocity);

        // Cambia direzione se raggiunge un limite di movimento
        if (isMovingRight && transform.position.x >= 5f)
        {
            ChangeDirection();
        }
        else if (!isMovingRight && transform.position.x <= -5f)
        {
            ChangeDirection();
        }
    }
private void UpdateAnimation()
    {
        if (dirX > 0f)
        {
            anim.SetBool("Skele_run", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("Skele_run", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("Skele_run", false); 
        }
    }
    private void ChangeDirection()
    {
        // Cambia la direzione del movimento
        isMovingRight = !isMovingRight;

        // Inverti la scala del nemico per mantenere l'orientamento corretto
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void CheckAttackRange()
    {
        // Calcola la distanza tra il nemico e il personaggio principale
        float distance = Vector2.Distance(transform.position, target.position);

        // Se il personaggio principale è abbastanza vicino, inizia l'attacco
        if (distance <= attackRange)
        {
            isAttacking = true;
            attackTimer = attackDuration;

            // Cambia la velocità del nemico per inseguire il personaggio principale
            speed = attackSpeed;
            // Aggiungi qui il codice per far attaccare il nemico al personaggio principale
        }
    }

    private void AttackTimer()
    {
        // Conta il tempo dell'attacco
        attackTimer -= Time.deltaTime;

        // Se il tempo dell'attacco è scaduto, smetti di attaccare
        if (attackTimer <= 0f)
        {
            isAttacking = false;

            // Ripristina la velocità di movimento normale del nemico
            speed = 2f;
        }
    }

    private void CooldownTimer()
    {
        // Conta il tempo di recupero tra gli attacchi
        cooldownTimer += Time.deltaTime;

        // Se il tempo di recupero è terminato, reimposta il timer e permetti nuovi attacchi
        if (cooldownTimer >= attackCooldown)
        {
            cooldownTimer = 0f;
        }
    }
}
