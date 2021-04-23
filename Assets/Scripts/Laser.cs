using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
	public float explosionForce = 5f;

	int howManyThingsHit = 0;

    public GameObject spawnItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	//create a ray in our scene from a point in our cameras view (from our screen) based on the mouse position
        Ray laser = Camera.main.ScreenPointToRay(Input.mousePosition);

        //store information about our ray hitting things in this RaycastHit
        RaycastHit hit = new RaycastHit();

        //Use the Raycast method to actually cast the ray into our scene
        //the first parameter is which ray
        //the second one is going to store the hit information into our RaycastHit (hit)
        //the third one is how far to send it into our scene
     	if (Physics.Raycast(laser, out hit, 10000f)) {

     		//use hit to access the name of the gameobject of the transform of the thing we hit
     		Debug.Log("you hit " + hit.transform.gameObject.name);

     		//demonstration code for modifying scale since that was part of last week's homework
     		//hit.transform.localScale += new Vector3(1f, 1f, 1f);

            if (Input.GetMouseButtonDown(1)){
                Instantiate(spawnItem, hit.point, Quaternion.identity);
            }

     		//there are three conditions here that must be true
     		//the thing we hit must have a rigidbody
     		//and the transform of the thing we hit must not be the same (!=) as the transform this script is attached to
     		if (hit.rigidbody && hit.transform != transform && Input.GetMouseButton(0)){
     			

     			//this code executes if the above conditions are true
     			//if so, access the rigidbody of the thing we hit and run the AddExplosionForce method
     			//see the documentation page for what each parameter is
     			//(how much force, where should it occur, radius of explosion, upward force modifier)
     			hit.rigidbody.AddExplosionForce(explosionForce, hit.point, 10f, 1.5f);

     			howManyThingsHit++;
     			Debug.Log("you hit " + howManyThingsHit + " things");

     			hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.red;
     			//hit.transform.gameObject.GetComponent<Renderer>().material.color -= new Color(0f, 0.1f, 0.1f, 0f);
     			//Destroy(hit.transform.gameObject);
     		}
     	}  
    }
}
