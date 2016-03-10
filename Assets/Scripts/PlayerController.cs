using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	public float speed;

	private Rigidbody rb;

	Vector3 offsetAcceleration;
	Vector3 initialAcceleration;

	void Start ()
	{
		initialAcceleration = Input.acceleration;
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate ()
	{
		//float moveHorizontal = Input.GetAxis ("Horizontal");
		//float moveVertical = Input.GetAxis ("Vertical");
		offsetAcceleration = Input.acceleration - initialAcceleration;
		float moveHorizontal = offsetAcceleration.x;
		float moveVertical = offsetAcceleration.y;

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed * Time.deltaTime);
	}
}