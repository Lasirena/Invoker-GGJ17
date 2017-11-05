using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


	public int MonsterLimit = 10;

	public List<GameObject> monsters;

	public int score = 0;

	public Text textUI;

	public static int currentScore = 0;
		
	// Use this for initialization
	void Start () {
		foreach (GameObject monster in GameObject.FindGameObjectsWithTag("Monster"))
		{
			if (monster.GetComponent<MonsterAI>().isAlive)
			{
				monsters.Add(monster);
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		score = currentScore;
		textUI.text = "Score: " + score.ToString();
	}
}