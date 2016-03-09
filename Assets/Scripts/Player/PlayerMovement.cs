using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;

	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100f;

	Vector3 offsetAcceleration;
	Vector3 initialAcceleration;

	void Awake()
	{
		initialAcceleration = Input.acceleration;
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
		//float h = Input.GetAxisRaw ("Horizontal");
		//float v = Input.GetAxisRaw ("Vertical");

		offsetAcceleration = Input.acceleration - initialAcceleration;
		float h = offsetAcceleration.x;
		float v = offsetAcceleration.y;
		if (Mathf.Abs(h) < 0.1)
			h = 0.0f;
		if (Mathf.Abs(v) < 0.1)
			v = 0.0f;
		Move (h, v);

		Turning ();

		Animating (h, v);
	}
	void Move (float h, float v)
	{
		movement.Set (h, 0f, v);

		movement = movement.normalized * speed * Time.deltaTime;

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
