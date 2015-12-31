using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour {
	
	public float MovementReduction;
	public bool Grounded = false;

	PlayerMovement movement;

	void Start() {
		movement = gameObject.GetComponent<PlayerMovement>();
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Projectile")) {
			float newSpeed = movement.walkSpeed - MovementReduction;
			if (newSpeed <= 0) {
				Grounded = true;
				newSpeed = 0;
			}
			movement.walkSpeed = newSpeed;
			movement.runSpeed = newSpeed + newSpeed * 1.75f;
		}
	}	
}
