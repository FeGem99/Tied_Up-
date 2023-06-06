
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
    private string CustomOrizontalAxisName = "Horizontal_2";
    private string CustomJump = "Jump_2"; 
   private void Start()
    {
       zelena =  GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {

        float dirXZ = customInputManager.GetAxisRaw(CustomOrizontalAxisName);
        zelena.velocity = new Vector2(dirXZ * 2f, zelena.velocity.y);
       if (customInputManager.GetAxisRaw(CustomJump))
       {
      zelena.velocity = new Vector3(zelena.velocity.x, 4f);
      transform.translate(Zelena_Movement);
      } 
        if (dirXZ > 0){

        }


    }
}

