using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// This class will handle all the player's stealth movement and behaviors
public class PlayerStealth : MonoBehaviour {

	public bool isActive = true; // Is this player currently selected and ready to move
	public bool isInCover;
	public float coverDistance = 20f;

	List<Collider> possibleCoverPositions = new List<Collider>();

	void Update() {
		if (isInCover) {
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
			determineCoverObjectBasedOnRaycast();
		}
	}
		
	// Will eventually want to return hit gameobject
	void determineCoverObjectBasedOnRaycast() {
		RaycastHit hit;
		GameObject hitObject;

		Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
		Vector3 drawPos = new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z);
		Debug.DrawRay(drawPos, forward, Color.green, coverDistance, true);
		if (Physics.Raycast(drawPos, forward, out hit, coverDistance)) {
			hitObject = hit.collider.gameObject;
			if (hitObject.CompareTag("CoverObject")) {
				hitObject.GetComponent<CoverObject>().DisplayCoverIndicator();	
			}
		}
	}
}
