using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
	public static readonly int NORMAL = 0, DASH = 1;
	public float speed = 6f;
	public float dashSpeed = 50f;

	public int startingMana = 100;
	public int currentMana;
	public Slider manaSlider;

	public float maxTimeDash = 10.0f;

	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;
	int floorMask;
//	float camRayLength = 100f;

	ParticleSystem dashParticles;

	Vector3 offsetAcceleration;
	Vector3 initialAcceleration;

	public int playerStatus; 
	float timer;

	void Awake()
	{
		currentMana = startingMana;
		playerStatus = NORMAL;
		initialAcceleration = Input.acceleration;
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
		if (currentMana != 100) {
			currentMana += 2;
		}
		manaSlider.value = currentMana;

		Vector3 direction = transform.forward;
		if (playerStatus == DASH) {
			if (timer < maxTimeDash) {
				Move (direction.x, dashSpeed, direction.z);
				timer += 1f;
			} else {
				playerStatus = NORMAL;
			}
		} else {
			if (Input.touchCount > 0 && currentMana == 100) {
				playerStatus = DASH;
				timer = 0.0f;
				Move (direction.x, dashSpeed, direction.z);
				currentMana = 0;
			} else {
				offsetAcceleration = Input.acceleration - initialAcceleration;
				float h = offsetAcceleration.x;
				float v = offsetAcceleration.y;

				if (Mathf.Abs(h) < 0.1)
					h = 0.0f;
				if (Mathf.Abs(v) < 0.1)
					v = 0.0f;

				Move (h, speed, v);
				Turning ();
				Animating (h, v);
			}
		}
	}
	void Move (float h, float s, float v)
	{
		movement.Set (h, 0f, v);

		movement = movement.normalized * s * Time.deltaTime;
		Debug.Log (movement.normalized);
		playerRigidbody.MovePosition (transform.position + movement);
	}

	void Turning ()
	{
		if (movement != Vector3.zero) {
			Vector3 playerToMouse = movement;

			playerToMouse.y = 0f;
			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);

			playerRigidbody.MoveRotation (newRotation);
		}
	}

	void Animating (float h, float v)
	{
		bool walking = h != 0f || v != 0f;

		anim.SetBool ("IsWalking", walking);
	}
}
