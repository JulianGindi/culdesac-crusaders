using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float movementSpeed = 0.6f;
	public float turnSmoothing = 15f;
	public float smoothTime = 0.3F;

	float horizontalInput;
	float verticalInput;
	Vector3 velocity = Vector3.zero;
	Animator anim;

	Rigidbody rb;

	void Awake () {
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveVertical = Input.GetAxisRaw ("Vertical");
		
		MoveCharacter (moveHorizontal, moveVertical);
	}
	
	void MoveCharacter(float h, float v) {
		if (h != 0f || v != 0f) {
			Vector3 movement = new Vector3 (h, 0.0f, v);
			Rotating (h, v);

			// Normalise the movement vector and make it proportional to the speed per second.
			movement = movement.normalized * movementSpeed * Time.deltaTime;
			
			// Move the player to it's current position plus the movement.
			rb.MovePosition (transform.position + movement);
			anim.SetBool ("isRunning", true);
		} else {
			anim.SetBool ("isRunning", false);
		}
	}
	
	void Rotating(float horizontal, float vertical) {
		Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
		
		// Create a rotation based on this new vector assuming that up is the global y axis.
		Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
		
		// Create a rotation that is an increment closer to the target rotation from the player's rotation.
		Quaternion newRotation = Quaternion.Lerp(rb.rotation, targetRotation, turnSmoothing * Time.deltaTime);
		
		// Change the players rotation to this new rotation.
		rb.MoveRotation(newRotation);
	}
}
