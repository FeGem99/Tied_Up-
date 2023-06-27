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
 private Animator anim; //variabile per animazione

 [SerializeField] private LayerMask JumpableGround; 
   /* int wholeNumber = 16;
    float decimalNumber = 4.54f;
    string text = "this->";
    bool boolean = false;*/
    // Start is called before the first frame update
   private void Start()
    {
       zelena =  GetComponent<Rigidbody2D>();
       coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
       //int jumpD = 0;
    }

    // Update is called once per frame
    private void Update()
    {
         
        dirX = Input.GetAxisRaw("HorizontalZ");
        zelena.velocity = new Vector2(dirX * 3.5f, zelena.velocity.y);
       if (Input.GetButtonDown("JumpZ") && isGrounded())
       {
        
      zelena.velocity = new Vector3(zelena.velocity.x, 5.5f);
      isJumping=true;
      } 
       UpdateAnimationUpdate();

       
    }
    private void UpdateAnimationUpdate(){ //metodo che controlla le animazioni di durdust 

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
      else {
          anim.SetBool("run_Z", false); 

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


