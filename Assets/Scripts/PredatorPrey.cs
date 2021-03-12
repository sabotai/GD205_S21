using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorPrey : MonoBehaviour
{
	Rigidbody myRb; //make a new rigidbody called myRb
	public Transform target; //assign in the inspector to whatever our target is (player saucer)
	public float thrustAmt = 3f; //make it public to manipulate in the inspector

	public float awarenessThresh = 5f; //a variable to determine how far the target must be to react to it

    // Start is called before the first frame update
    void Start()
    {
     	  myRb = GetComponent<Rigidbody>(); //assign it to the rigidbody attached to the same gameobject
    }

    // Update is called once per frame
    void Update()
    {

    	//Vector3.Distance will give us the distance between two transforms
    	//imagine it using a tape measure between the two transforms
    	//if it is LESS than the awarenessThresh distance, then run the chase/run away code
    	if (Vector3.Distance(target.position, transform.position) < awarenessThresh){
	    	//use the addforce method of the rigidbody to add force in a certain direction
	    	//by subtracting our position from a target position, it will give us the relative direction
	    	//we multiply by thrustAmt to control how much force to add
	       myRb.AddForce(Vector3.Normalize(target.position - transform.position) * thrustAmt);

	       //use the f key to reverse the relationship between predator and prey
	       //this is just a demo
	       //if (Input.GetKeyDown(KeyCode.F)){
	       	//thrustAmt *= -1f; //by multiplying by -1 it will reverse the direction of travel
	       //}

   		}

    }
}
