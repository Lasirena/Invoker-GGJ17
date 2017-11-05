using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    //public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime;

    public GameObject manager;

	void Start () {

        InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);
	}

    void SpawnEnemy() {

        /*
        if (playerHealth.currentValue <= 0) {
            return;
        } */
        //else {
        
        if (manager.GetComponent<GameManager>().monsters.Count < manager.GetComponent<GameManager>().MonsterLimit)
        {
            Instantiate(enemy, transform.position, transform.rotation);
        }

        manager.GetComponent<GameManager>().monsters.Clear();

        foreach (GameObject monster in GameObject.FindGameObjectsWithTag("Monster"))
		{
			if (monster.GetComponent<MonsterAI>().isAlive)
			{
				manager.GetComponent<GameManager>().monsters.Add(monster);
			}
		}
        //}
    }
}