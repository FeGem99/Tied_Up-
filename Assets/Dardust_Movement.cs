using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dardust_Movement : MonoBehaviour
{

   private Rigidbody2D dardust;
   private bool isJumping = false;

private float dirX = 0f; //variabile che indica la direzione dove si muove durdust, settata a 0.
   private Animator anim; //variabile per animazione
   /* int wholeNumber = 16;
    float decimalNumber = 4.54f;
    string text = "this->";
    bool boolean = false;*/
    // Start is called before the first frame update
   private void Start()
    {
       dardust =  GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");
        dardust.velocity = new Vector2(dirX * 3.5f, dardust.velocity.y);
       if (Input.GetButtonDown("Jump")&& !isJumping)
       {
      dardust.velocity = new Vector3(dardust.velocity.x, 5.5f);
      isJumping = true;
      } 

      UpdateAnimationUpdate();

    }

private void UpdateAnimationUpdate(){ //metodo che controlla le animazioni di durdust 

if (dirX > 0f)
      {
          anim.SetBool("Running_D", true);
      }
      else if (dirX < 0f)
      {
          anim.SetBool("Running_D", true);
      }
      else {
          anim.SetBool("Running_D", false); 
      }
}
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Terrain")){
            isJumping = false;
        }
    }
}

