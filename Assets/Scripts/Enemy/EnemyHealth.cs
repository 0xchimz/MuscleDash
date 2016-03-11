using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int point = 10;
	public int fullHp = 100;
	public int hp;
	public float sinkSpeed = 2.5f;
	public int scoreValue = 10;

	AudioSource enemyAudio;
	ParticleSystem hitParticles;
	Enemy enemy;

	void Awake ()
	{
		enemy = GetComponent <Enemy> ();
		enemyAudio = GetComponent <AudioSource> ();
		hitParticles = GetComponentInChildren <ParticleSystem> ();

		hp = fullHp;
	}

	void Update ()
	{
		if (enemy.IsSinking()) {
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
		}
	}

	public void TakeDamage (int amount)
	{
		if (enemy.IsDead())
			return;
	
		enemyAudio.Play ();
		hp -= amount;

		if (hp <= 0) {
			hp = 0;
			enemy.Death ();
		}
	}

	public void KnockBack (Vector3 direction) {
		hitParticles.transform.position = direction;

		hitParticles.Play ();
	}

	void OnParticleCollision(GameObject other) {
		TakeDamage (100);
		Debug.Log ("OnParticleCollision: " + other.name);
	}
}
