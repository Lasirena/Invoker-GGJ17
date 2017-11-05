using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    

    public string targetString;

    private Transform target;   // 
    private NavMeshAgent agent;

    //private EnemyHealth health;
    //private PlayerHealth playerHealth;

	
	void Start () {

        target = GameObject.FindGameObjectWithTag(targetString).transform;
        agent = GetComponent<NavMeshAgent>();

        //health = GetComponent<EnemyHealth>();
        //playerHealth = player.GetComponent<PlayerHealth>();
    }
	
	
	void Update () {

        //if(playerHealth.currentValue > 0 && health.currentValue > 0) {
            agent.SetDestination(target.position);
        //}
        //else {
            //agent.Stop();
        //}


    }
}
