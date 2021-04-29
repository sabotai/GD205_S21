using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgent : MonoBehaviour
{
	NavMeshAgent enemyNavi;

    // Start is called before the first frame update
    void Start()
    {
        enemyNavi = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider col){
    	if (col.CompareTag("Player")){
    		enemyNavi.SetDestination(col.transform.position);
    	}
    }
}
