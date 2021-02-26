using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    //new code!!!!
	//we assigned these to be equivalent in each direction, so fwd = (x = 0, y = 0, z = 2) and bwd = (x = 0, y = 0, z = -2)
	public Vector3 fwd, bwd, lft, rgt, up, dwn;
    public Transform hazard, key, door, newRoom, oldRoom;
    Vector3 startPos;
    public bool hasKey;
    public AudioSource speaker;
    public AudioClip hazardClip;

    // Start is called before the first frame update
    void Start() //like setup
    {
        startPos = transform.position;
        hasKey = false;
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
        if (Input.GetKeyDown(KeyCode.S)) { 
           transform.position += bwd; 
        }
        if (Input.GetKeyDown(KeyCode.A)) { 
            transform.position += lft; 
        }
        if (Input.GetKeyDown(KeyCode.D)) {            
            transform.position += rgt; 
        }
        if (Input.GetKeyDown(KeyCode.Q)) { 
            transform.position += dwn; 
        }
        if (Input.GetKeyDown(KeyCode.E)) { 
            transform.position += up; 
        }

        if (hazard.position == transform.position) {
            transform.position = startPos;
            speaker.PlayOneShot(hazardClip, .7f);
        }
        if (key.position == transform.position) {
            hasKey = true;
            key.gameObject.SetActive(false);
        }
        if (door.position == transform.position && hasKey){
            newRoom.gameObject.SetActive(true);
            oldRoom.gameObject.SetActive(false);
            door.gameObject.SetActive(false);

        }


        for (int i = 0; i < oldRoom.childCount; i++){
            if (transform.position == oldRoom.GetChild(i).position){
                oldRoom.GetChild(i).gameObject.GetComponent<Renderer>().material.color += new Color(0.01f, 0.01f, 0.01f, 1f);
            }
        }

    }
}


