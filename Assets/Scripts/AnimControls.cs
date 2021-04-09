using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControls : MonoBehaviour
{

	Animator akai; //Create a new animator

    // Start is called before the first frame update
    void Start()
    {
        akai = GetComponent<Animator>(); //assign it to the Animator component attached to the same GameObject
    }

    // Update is called once per frame
    void Update()
    {
        akai.SetInteger("AnimState", 0);
        if (Input.GetKey(KeyCode.W)){ //if the key w is being pressed, then set the parameter value to 1
            akai.SetInteger("AnimState",1); //Animator.SetInteger will assign a value to the parameter indicated to the value 

            if (Input.GetKey(KeyCode.LeftShift)){
                akai.SetInteger("AnimState", 2);
                Debug.Log("should be working");
            }
        }

        /*
        if (Input.GetKey(KeyCode.C)){ //if the key w is being pressed, then set the parameter value to 1
            akai.SetInteger("AnimState",2); //Animator.SetInteger will assign a value to the parameter indicated to the value 
        }
        */
    }
}
