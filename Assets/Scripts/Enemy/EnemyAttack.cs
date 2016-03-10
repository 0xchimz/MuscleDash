using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
	public float timeBetweenAttacks = 0.5f;
	public int atk = 10;

	GameObject player;
	PlayerHealthPoint playerHp;
	EnemyHealth enemyHealth;
	bool playerInRange;
	float timer;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHp = player.GetComponent <PlayerHealthPoint> ();
		enemyHealth = GetComponent<EnemyHealth> ();
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == player) {
			playerInRange = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == player) {
			playerInRange = false;
		}
	}

	void Update ()
	{
		timer += Time.deltaTime;

		if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.hp > 0) {
			Attack ();
		}
	}

	void Attack ()
	{
		timer = 0f;
		playerHp.TakeDamage (atk);
	}
}
