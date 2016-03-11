using UnityEngine;
using System.Collections;

public class ReadyToUse : MonoBehaviour {

	ParticleSystem p;
	Player player;
	// Use this for initialization
	void Start () {
		p = GetComponent<ParticleSystem> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Debug.Log (player.getSP () >= 90);
		if (player.getSP () >= 90) {
			if (!p.isPlaying) {
				p.Play ();
			}
		} else if (player.getStatus () == Player.SKILL) {
			p.Stop ();
		}
	}
}
