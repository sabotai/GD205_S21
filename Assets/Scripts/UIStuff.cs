using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //add the directive for UI functionality
using UnityEngine.SceneManagement;//add the directive for SceneManagement functionality (loading scenes)

public class UIStuff : MonoBehaviour
{

	public Text coinUI; //we assign this to be the UI text gameobject
	public int coinCount; //an int to keep track of how many coins the player has picked up
    public Text timer;
    public float timerAmount;

    // Start is called before the first frame update
    void Start()
    {
        //coinUI = GetComponent<Text>(); //old way when we it was attached to the same gameobject
        coinCount = 0; //start the count at 0
    }

    // Update is called once per frame
    void Update()
    {
        //modify the text property of the Text object
        //set it to how many coins have been collected followed by " coins"
       coinUI.text = coinCount + " coins"; 

       timer.text = " " + (timerAmount - (int)Time.timeSinceLevelLoad);

       if (Time.timeSinceLevelLoad > timerAmount){
            ReloadScene();
       }
    }

    //OnTriggerEnter will run anytime this gameobject collides with another collider marked as a trigger
    void OnTriggerEnter(Collider col){ //it will store the information about that trigger in col
    	Debug.Log("trigger entered"); //tell us in the console so we know its working
    	if (col.CompareTag("Collectible")){ //check if the trigger we hit has the tag "Collectible"
    		//if (coinCount < 2){
    			coinCount++; //take however many coinCount is and add 1 to it
    			Destroy(col.gameObject); //then destroy the object that has been collected
    		//}
    	}
    }

    //custom function for reloading the scene
    //this wont run on its own... we have to use the button element to run OnClick (look at the component in the inspector)
    public void ReloadScene(){

        //load the scene with the index of 0
        //the index is based on the scenes listed in File->Build Settings
    	SceneManager.LoadScene(0);
    }

    //another custom function for quitting the game
    //this function will only run if we call it somewhere else, such as in a button's OnClick
    public void QuitGame(){

        //Application.Quit() is the function to quit the game entirely (only works in a desktop build)
        Application.Quit();

    }
}
