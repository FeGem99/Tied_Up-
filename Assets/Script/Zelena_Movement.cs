using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zelena_Movement : MonoBehaviour
{
    private Rigidbody2D zelena;
    private BoxCollider2D coll;
    private bool isJumping = false;
    private float dirX = 0f;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask JumpableGround;
    [SerializeField] private LayerMask JumpableObstacles;

    public int maxHealth = 3;
    private int currentHealth;

    private void Start()
    {
        zelena = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        currentHealth = maxHealth;
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("HorizontalZ");
        zelena.velocity = new Vector2(dirX * 3.5f, zelena.velocity.y);

        if (Input.GetButtonDown("JumpZ") && (isGrounded() || isObstacleColliding()))
        {
            zelena.velocity = new Vector2(zelena.velocity.x, 5.5f);
            isJumping = true;
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (dirX > 0f)
        {
            anim.SetBool("run_Z", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("run_Z", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("run_Z", false);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Aggiorna la barra della vita o esegui altre azioni in base alla vita attuale

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Logica per la morte del personaggio
        if(currentHealth==0)
        {
            anim.SetBool("Death", true);
        }
        // Puoi disattivare il personaggio, avviare un'animazione di morte, ecc.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            isJumping = false;
        }
    }

    private bool isGrounded()
    {
        float extraHeight = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, extraHeight, JumpableGround);
        return raycastHit.collider != null;
    }

    private bool isObstacleColliding()
    {
        float extraHeight = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, extraHeight, JumpableObstacles);
        return raycastHit.collider != null;
    }
}
