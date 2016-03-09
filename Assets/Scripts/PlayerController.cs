using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour {

	public float gravity = 20;
	public float speed = 20;
	public float acceleration = 30;
	public float jumpHeight = 14;

	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;

	Vector3 offsetAcceleration;
	Vector3 initialAcceleration;

	private PlayerPhysics PlayerPhysics;

	void Start () {
		initialAcceleration = Input.acceleration;
		PlayerPhysics = GetComponent<PlayerPhysics> ();
	}
	
	void Update () {
		offsetAcceleration = Input.acceleration - initialAcceleration;
		targetSpeed = offsetAcceleration.x * speed;

		if (PlayerPhysics.grounded) {
			amountToMove.y = 0;
			if (Input.touchCount > 0) {
				amountToMove.y = jumpHeight;
			}
		}
		if (PlayerPhysics.groundbot) {
			amountToMove.y = 0;
		}

		currentSpeed = IncrementTowards (currentSpeed, targetSpeed, acceleration);

		amountToMove.x = currentSpeed;
		amountToMove.y -= gravity * Time.deltaTime;
		PlayerPhysics.Move (amountToMove * Time.deltaTime);
	}

	private float IncrementTowards(float n, float target, float a) {
		if (n == target) {
			return n;	
		}
		else {
			float dir = Mathf.Sign(target - n);
			n += a * Time.deltaTime * dir;
			return (dir == Mathf.Sign(target-n))? n: target;
		}
	}
}
