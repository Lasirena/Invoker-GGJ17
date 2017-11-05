using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellChecker : MonoBehaviour {

	public GameObject FrontSpellChecker;
	public GameObject ProjectilePrefab;

	public GameObject forearmObj;

	public bool spellDone = false;

	public AudioSource audioSource;
	public AudioClip[] spell_FireClips;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.Equals(FrontSpellChecker))
		{
			Instantiate(ProjectilePrefab, forearmObj.transform.position, forearmObj.transform.rotation);
			PlayFireSpellSound();
		}
	}

	void OnTriggerExit()
	{
		spellDone = false;
	}

	void PlayFireSpellSound()
	{
		AudioClip randomClip = spell_FireClips[Random.Range(0, spell_FireClips.Length)];

		audioSource.PlayOneShot(randomClip);
	}
}