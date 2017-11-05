using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour {

	public bool isAlive = true;
	public Image healthBar;
	public float CurrentHealth = 500;
	public float MaxHealth = 500;


	float HealthPercentage;

	void Awake()
	{
		CurrentHealth = MaxHealth;
	}

	void Update () 
	{

		HealthPercentage = CurrentHealth/MaxHealth;
		healthBar.fillAmount = HealthPercentage;

		isAlive = (HealthPercentage > 0);

		if (!isAlive)
		{
			SceneManager.LoadScene(0);
		}
	}
}