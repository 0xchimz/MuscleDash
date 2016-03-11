using UnityEngine;
using System.Collections;

public class UseSkill : MonoBehaviour {

	ParticleSystem p;
	Player player;
	// Use this for initialization
	void Start () {
		p = GetComponent<ParticleSystem> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (player.getStatus () == Player.SKILL) {
			p.Play ();
		} else {
			p.Stop ();
		}
	}

}
