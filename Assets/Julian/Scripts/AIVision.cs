using UnityEngine;
using System.Collections;

public class AIVision : MonoBehaviour {

	public float fieldOfViewAngle = 110f;

	// This is a variable for testing purposes. Should be removed before shipping the game.
	// Has AI follow player character once they enter the "vision collider" instead of actually using realistic vision
	public bool dumbSight = false;

	[HideInInspector] // We don't want to see this in the editor...just want to be able to access it
	public bool playerInSight;

	[HideInInspector] // Same
	public Vector3 personalLastSighting;
	

	void Start() {
		playerInSight = false;
	}


	void OnTriggerStay(Collider other) {

		if (other.CompareTag("Player")) {

			// Create a vector from the enemy to the player and store the angle between it and forward.
			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle(direction, transform.forward);
		
			// If the angle between forward and where the player is, is less than half the angle of view...
			if(angle < fieldOfViewAngle * 0.5f || dumbSight == true)
				playerInSight = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.CompareTag("Player"))
			playerInSight = false;
	}
}
