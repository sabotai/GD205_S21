using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIStuff : MonoBehaviour
{

	public Text coinUI;
	public int coinCount;

    // Start is called before the first frame update
    void Start()
    {
        //coinUI = GetComponent<Text>();
        coinCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
       coinUI.text = coinCount + " coins";
    }

    void OnTriggerEnter(Collider col){
    	Debug.Log("trigger entered");
    	if (col.CompareTag("Collectible")){
    		//if (coinCount < 2){
    			coinCount++;
    			Destroy(col.gameObject);
    		//}
    	}
    }

    public void ReloadScene(){
    	SceneManager.LoadScene(0);
    }
}
