using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// This class will handle all the player's stealth movement and behaviors
public class PlayerStealth : MonoBehaviour {

	public bool isActive = true; // Is this player currently selected and ready to move
	public bool isInCover;

	List<Collider> possibleCoverPositions = new List<Collider>();

	void Start () {
		isInCover = false;
	}

	void Update() {
		drawDebugRaycast();

		if (isInCover) {
			float horizontalI = Input.GetAxis("Horizontal");
			float verticalI = Input.GetAxis("Vertical");

			Quaternion coverDirection = rotationBasedOnInput(horizontalI, verticalI);
			GameObject coverObject = determineCoverObjectBasedOnRaycast(coverDirection);
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("CoverObject") && !possibleCoverPositions.Contains(other)) {
			possibleCoverPositions.Add(other);
		}
	}
		
	void OnTriggerExit(Collider other) {
		if(other.CompareTag("CoverObject") && possibleCoverPositions.Contains(other)) {
			possibleCoverPositions.Remove(other);
		}
	}

	void drawDebugRaycast() {
		Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
		Vector3 drawPos = new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z);
		Debug.DrawRay(drawPos, forward, Color.green, 20f, true);
	}

	Quaternion rotationBasedOnInput(float horizontal, float vertical) {
		Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
		Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
	}

	GameObject determineCoverObjectBasedOnRaycast(Quaternion direction) {
		GameObject nextCoverObject;
		// Draw a raycast based on provided direction
		// check if you get a "CoverObject"
		// return said CoverObject
		return nextCoverObject;
	}
}
