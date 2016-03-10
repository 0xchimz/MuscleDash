using UnityEngine;
using System.Collections;

public class PlayerDashing : MonoBehaviour
{
	TrailRenderer dashParticles;
	GameObject player;
	PlayerMovement playerMovement;

	void Awake()
	{
		dashParticles = GetComponent<TrailRenderer> ();
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		playerMovement = player.GetComponent<PlayerMovement> ();
	}

	void FixedUpdate()
	{
		if (playerMovement.playerStatus == PlayerMovement.DASH) {
			dashParticles.enabled = true;
		} else if(playerMovement.playerStatus == PlayerMovement.NORMAL){
			dashParticles.enabled = false;
		}
	}
}
/*    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
	public float range = 1f;

	public float timeBetweenAttacks = 0.1f;
	public int attackDamage = 10;


    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
//    float effectsDisplayTime = 0.2f;

	bool enermyInRange;
	GameObject enemy;
	EnemyHealth enemyHealth;
	Animator anim;

    void Awake ()
    {
		enemy = GameObject.FindGameObjectWithTag ("Shootable");
		enemyHealth = enemy.GetComponent<EnemyHealth> ();
		Debug.Log (enemyHealth);
		anim = enemy.GetComponent <Animator> ();

        shootableMask = LayerMask.GetMask ("Shootable");
        gunParticles = GetComponent<ParticleSystem> ();
        //gunLine = GetComponent <LineRenderer> ();
        //gunAudio = GetComponent<AudioSource> ();
        //gunLight = GetComponent<Light> ();
    }


    void Update ()
    {
        timer += Time.deltaTime;

		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot ();
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
		timer += Time.deltaTime;

		if(timer >= timeBetweenAttacks && enermyInRange && enemyHealth.currentHealth > 0)
		{
			Attack ();
		}

		if(enemyHealth.currentHealth <= 0)
		{
			anim.SetTrigger ("Dead");
		}
    }

	void Attack ()
	{
		timer = 0f;

		if(enemyHealth.currentHealth > 0)
		{
			enemyHealth.TakeDamage (attackDamage, transform.forward);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == enemy)
		{
			enermyInRange = true;
		}
	}


	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == enemy)
		{
			enermyInRange = false;
		}
	}

    public void DisableEffects ()
    {
        gunLine.enabled = false;
        //gunLight.enabled = false;
    }


    void Shoot ()
    {
        timer = 0f;

        //gunAudio.Play ();

        //gunLight.enabled = true;

        gunParticles.Stop ();
        gunParticles.Play ();

        //gunLine.enabled = true;
        //gunLine.SetPosition (0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage (damagePerShot, shootHit.point);
            }
            //gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
            //gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
    }
}
*/