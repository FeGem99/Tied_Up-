using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zelena_Movement : MonoBehaviour
{

   private Rigidbody2D zelena;
   /* int wholeNumber = 16;
    float decimalNumber = 4.54f;
    string text = "this->";
    bool boolean = false;*/
    // Start is called before the first frame update
   private void Start()
    {
       zelena =  GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {

        float dirXZ = Input.GetAxisRaw("Horizontal_Z");
        zelena.velocity = new Vector2(dirXZ * 2f, zelena.velocity.y);
       if (Input.GetButtonDown("Jump_Z"))
       {
      zelena.velocity = new Vector3(zelena.velocity.x, 4f);
      } 
        if (dirXZ > 0){

        }


    }
}
