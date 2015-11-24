using UnityEngine;
using System.Collections;

public class SecurityCameraController : MonoBehaviour {
	
	public float fieldOfViewAngle = 110f;
	
	[HideInInspector] // We don't want to see this in the editor...just want to be able to access it
	public bool playerInSight;


	void Start() {
		playerInSight = false;
	}
	
	
	void OnTriggerStay(Collider other) {
		
		if (other.CompareTag("Player")) {
			
			// Create a vector from the enemy to the player and store the angle between it and forward.
			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle(direction, transform.forward);
			
			// If the angle between forward and where the player is, is less than half the angle of view...
			if(angle < fieldOfViewAngle * 0.5f)
				print ("Seen by security camera");
				playerInSight = true;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.CompareTag("Player"))
			playerInSight = false;
	}
}