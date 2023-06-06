using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dardust_Movement : MonoBehaviour
{

   private Rigidbody2D dardust;
   /* int wholeNumber = 16;
    float decimalNumber = 4.54f;
    string text = "this->";
    bool boolean = false;*/
    // Start is called before the first frame update
   private void Start()
    {
       dardust =  GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {

        float dirX = Input.GetAxisRaw("Horizontal");
        dardust.velocity = new Vector2(dirX * 2f, dardust.velocity.y);
       if (Input.GetButtonDown("Jump"))
       {
      dardust.velocity = new Vector3(dardust.velocity.x, 4f);
      } 
        if (dirX > 0){

        }


    }
}

