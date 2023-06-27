using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dardust_Movement : MonoBehaviour
{

   private Rigidbody2D dardust;
   private BoxCollider2D coll;
   private bool isJumping = false;
    private SpriteRenderer sprite;
private float dirX = 0f; //variabile che indica la direzione dove si muove durdust, settata a 0.
   private Animator anim; //variabile per animazione
   [SerializeField] private LayerMask JumpableGround;
   /* int wholeNumber = 16;
    float decimalNumber = 4.54f;
    string text = "this->";
    bool boolean = false;*/
    // Start is called before the first frame update
   private void Start()
    {
       dardust =  GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
       sprite = GetComponent<SpriteRenderer>();
       coll = GetComponent<BoxCollider2D>(); 
    }

    // Update is called once per frame
    private void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");
        dardust.velocity = new Vector2(dirX * 3.5f, dardust.velocity.y);
       if (Input.GetButtonDown("Jump")&& isGrounded())
       {
      dardust.velocity = new Vector3(dardust.velocity.x, 5.5f);
      isJumping = true;
      } 

      UpdateAnimationUpdate();

    }

private void UpdateAnimationUpdate(){ //metodo che controlla le animazioni di durdust 

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
      else {
          anim.SetBool("run_D", false); 
         
      }
}
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Terrain")){
            isJumping = false;
        }
    }
    private bool isGrounded(){
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, JumpableGround);
    }
}

