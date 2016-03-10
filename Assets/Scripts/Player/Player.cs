using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public static readonly int NORMAL = 0, DASH = 1;
	public float speed = 6f;
	public float dashSpeed = 25f;

	public int fullMana = 100;
	public int mana;
	public Slider manaSlider;
	public int atk = 1000;

	public float maxTimeDash = 10.0f;

	Vector3 movement;
	Animator anim;
	Rigidbody rigidbody;

	public TrailRenderer dashParticles;

	Vector3 offsetAcceleration;
	Vector3 initialAcceleration;

	int status;
	float timer;

	void Awake ()
	{
		mana = fullMana;
		status = NORMAL;
		initialAcceleration = Input.acceleration;
		anim = GetComponent<Animator> ();
		rigidbody = GetComponent<Rigidbody> ();
		manaSlider.maxValue = fullMana;
	}

	void FixedUpdate ()
	{
		if (mana != 300) {
			mana += 2;
		}

		manaSlider.value = mana;

		Vector3 direction = transform.forward;
		if (status == DASH) {
			if (timer < maxTimeDash) {
				Move (direction.x, dashSpeed, direction.z);
				timer += 1f;
			} else {
				status = NORMAL;
			}
			dashParticles.enabled = true;
		} else if (status == NORMAL) {
			if (Input.touchCount > 0 && mana >= 100) {
				status = DASH;
				timer = 0.0f;
				Move (direction.x, dashSpeed, direction.z);
				mana -= 100;
			} else {
				offsetAcceleration = Input.acceleration - initialAcceleration;
				float h = offsetAcceleration.x;
				float v = offsetAcceleration.y;

				if (Mathf.Abs (h) < 0.1)
					h = 0.0f;
				if (Mathf.Abs (v) < 0.1)
					v = 0.0f;

				Move (h, speed, v);
				Turning ();
				Animating (h, v);
			}
			dashParticles.enabled = false;
		}
	}

	void Move (float h, float s, float v)
	{
		movement.Set (h, 0f, v);

		movement = movement.normalized * s * Time.deltaTime;
		rigidbody.MovePosition (transform.position + movement);
	}

	void Turning ()
	{
		if (movement != Vector3.zero) {
			Vector3 playerToMouse = movement;

			playerToMouse.y = 0f;
			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);

			rigidbody.MoveRotation (newRotation);
		}
	}

	void Animating (float h, float v)
	{
		bool walking = h != 0f || v != 0f;
		anim.SetBool ("IsWalking", walking);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Enemy" && status == DASH) {
//			Debug.Log (other.gameObject.name);

			Vector3 direction = transform.position;

			other.gameObject.SendMessage ("TakeDamage", atk);
			other.gameObject.SendMessage ("KnockBack", direction);
		}
	}

}
