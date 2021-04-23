using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucerThrust : MonoBehaviour
{

	Rigidbody rb; //create a new rigidbody called rb
	public float thrustAmt = 10f;//make it public to manipulate in the inspector

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();//assign it to the rigidbody attached to the same gameobject
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)){ //if the W key is being pressed at this moment
        	rb.AddForce(new Vector3(0f,0f,1f) * thrustAmt); //addforce in the direction forward (1 on the z axis)
        }
        if (Input.GetKey(KeyCode.S)){//if the S key is being pressed at this moment
        	rb.AddForce(new Vector3(0f,0f,-1f) * thrustAmt);//addforce in the direction backward (-1 on the z axis)
        }
        if (Input.GetKey(KeyCode.Q)){ //same for Q
            rb.AddForce(new Vector3(0f, -1f, 0f) * thrustAmt); //same for down
        }
        if (Input.GetKey(KeyCode.E)){ //same for E
            rb.AddForce(new Vector3(0f, 1f, 0f) * thrustAmt); //same for up
        }
        if (Input.GetKey(KeyCode.D)){ //same for D
            rb.AddForce(new Vector3(1f, 0f, 0f) * thrustAmt); //same for right
        }
        if (Input.GetKey(KeyCode.A)){ //same for A
            rb.AddForce(new Vector3(-1f, 0f, 0f) * thrustAmt); //same for left
        }

        if (Input.GetKey(KeyCode.Space)){
        	rb.velocity *= 0.95f; //if we multiply by 95%, then it will slow down by 5% each frame this runs while the spacebar is being pressed
        }
    }

    //OnCollisionEnter will run any time this gameObject collides with something else
    void OnCollisionEnter(Collision colReport){ //it will store the information about the collision in a new Collision we are calling "colReport"

        //we are using Debug.Log to communicate in the console giving us the name of the gameObject weve hit
        Debug.Log("FKCKK!!! You hit " + colReport.gameObject.name);

        //we access the particlesystem attached to the same gameObject and run the Play() method to start playing the particlesystem
        GetComponent<ParticleSystem>().Play();
    }
}
