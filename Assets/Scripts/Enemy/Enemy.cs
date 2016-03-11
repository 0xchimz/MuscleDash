using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	Transform player;
	CapsuleCollider capsuleCollider;
	NavMeshAgent nav;
	Animator anim;
	AudioSource enemyAudio;

	public int point = 10;
	public AudioClip deathClip;

	bool isDead;
	bool isSinking;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		capsuleCollider = GetComponent <CapsuleCollider> ();
		nav = GetComponent <NavMeshAgent> ();
		anim = GetComponent <Animator> ();
		enemyAudio = GetComponent <AudioSource> ();
	}

	void Update ()
	{
		if (!isDead) {
			nav.SetDestination (player.position);
		}
	}

	public bool IsSinking()
	{
		return isSinking;
	}

	public bool IsDead()
	{
		return isDead;
	}

	public void Death ()
	{
		isDead = true;

		capsuleCollider.isTrigger = true;
		anim.SetTrigger ("Dead");

		enemyAudio.clip = deathClip;
		enemyAudio.Play ();

		GameController.instance.AddScore (point);
	}

	public void StartSinking ()
	{
		GetComponent <NavMeshAgent> ().enabled = false;
		GetComponent <Rigidbody> ().isKinematic = true;
		isSinking = true;
		Destroy (gameObject, 2f);
	}

}
