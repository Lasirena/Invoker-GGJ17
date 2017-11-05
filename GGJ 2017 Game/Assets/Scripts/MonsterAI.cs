using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class MonsterAI : MonoBehaviour {

	public bool isAlive = true;
	public bool hasTarget = true;
	public bool isAttacking = false;
	public Transform player;
	public float damageAmount = 10f;

	public float myHealth = 20;

	NavMeshAgent agent;
	Animator animator;

	public float bodyDestroyTime = 5;

	public AudioSource audioSource;
	public AudioClip[] zombieDeathClips;
	void Awake () 
	{
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
		player = GameObject.FindWithTag("Player").transform;
	}
	
	bool finishedDying = false;

	void Update () 
	{
		isAlive = (myHealth > 0);

		if (isAlive)
		{
			hasTarget = player.gameObject.GetComponent<PlayerStatus>().isAlive;

			isAttacking = ((agent.velocity == Vector3.zero) && hasTarget);

			if (hasTarget)
			{
				agent.SetDestination(player.position);
				
				animator.SetFloat("speed", agent.velocity.magnitude);
				animator.SetBool("attacking", isAttacking);			
			}
			else
			{
				agent.Stop();
			}
		}
		else
		{
			if (!finishedDying)
			{
				GetComponent<CapsuleCollider>().enabled = false;
				agent.enabled = false;
				animator.SetBool("isDead", !isAlive);
				PlayDeathSound();
				GameManager.currentScore += 1;
				StartCoroutine(Disappear());
				finishedDying = true;
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (isAlive)
		{
			if (other.CompareTag("Projectile"))
			{
				Destroy(other.gameObject);
				
				myHealth -= other.gameObject.GetComponent<ProjectileController>().damage;
			}
		}
	}

	void DealDamage()
	{
		player.gameObject.GetComponent<PlayerStatus>().CurrentHealth -= damageAmount;
	}

	void PlayDeathSound()
	{
		if (!audioSource.isPlaying)
		{
			AudioClip randomClip = zombieDeathClips[(int)Random.Range(0, zombieDeathClips.Length)];
			audioSource.PlayOneShot(randomClip);
		}
	}

	IEnumerator Disappear()
	{
		yield return new WaitForSeconds(bodyDestroyTime);
		Destroy(this.gameObject);
	}
}