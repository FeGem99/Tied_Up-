using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dardust_Movement : MonoBehaviour
{
    private Rigidbody2D dardust;
    private BoxCollider2D coll;
    private bool isJumping = false;
    private SpriteRenderer sprite;
    private float dirX = 0f;
    private Animator anim;
    [SerializeField] private LayerMask JumpableGround;
     [SerializeField] private LayerMask JumpableObstacle;
    private void Start()
    {
        dardust = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dardust.velocity = new Vector2(dirX * 3.5f, dardust.velocity.y);

        if (Input.GetButtonDown("Jump") && (isGrounded() || isObstacleColliding()))
        {
            dardust.velocity = new Vector2(dardust.velocity.x, 5.5f);
            isJumping = true;
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (dirX > 0f)
        {
            anim.SetBool("run_D", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("run_D", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("run_D", false);
        }
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
        RaycastHit2D raycastHit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, extraHeight, JumpableObstacle);
        return raycastHit.collider != null;
    }
}
