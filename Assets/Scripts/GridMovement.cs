using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{

	//we assigned these to be equivalent in each direction, so fwd = (x = 0, y = 0, z = 2) and bwd = (x = 0, y = 0, z = -2)
	public Vector3 fwd;

    // Start is called before the first frame update
    void Start() //like setup
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    	//access the Input class method called GetKeyDown, which takes a KeyCode parameter
    	//This will return true when this specific key is pressed down and false when it isn't
        if (Input.GetKeyDown(KeyCode.W)) { 

        	
        	//this is similar to print or println in processing
        	Debug.Log("you pressed w :)");


        	//modify the position of the transform of whatever gameobject this is attached to
        	//offset it by fwd (move from the current position to the current position plus the value of fwd)
        	transform.position += fwd; 
        }

    }
}
