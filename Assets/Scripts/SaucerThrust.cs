using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucerThrust : MonoBehaviour
{

	Rigidbody rb;
	public float thrustAmt = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)){
        	rb.AddForce(new Vector3(0f,0f,1f) * thrustAmt);
        }
        if (Input.GetKey(KeyCode.S)){
        	rb.AddForce(new Vector3(0f,0f,-1f) * thrustAmt);
        }

        if (Input.GetKey(KeyCode.Space)){
        	rb.velocity *= 0.95f;
        }
    }
}
