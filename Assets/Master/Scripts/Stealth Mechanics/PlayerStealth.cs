using UnityEngine;
using System.Collections;

// This class will handle all the player's stealth movement and behaviors
public class PlayerStealth : MonoBehaviour {

	public bool isActive = true; // Is this player currently selected and ready to move
	public bool isInCover;

	GameObject[] possibleCoverPositions;

	void Start () {
		isInCover = false;
	}

	void Update() {
		drawDebugRaycast();
	}

	// This function will store a list of points the player can move to
	void getPossibleCoverPositions() {
		possibleCoverPositions = GameObject.FindGameObjectsWithTag("CoverObject");
	}

	// This function will allow the player to select cover
	// using standard movement controls. Point will illuminate when selected
	void selectCoverPosition() {
		
	}

	void drawDebugRaycast() {
		Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
		Vector3 drawPos = new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z);
		Debug.DrawRay(drawPos, forward, Color.green, 20f, true);
	}
}
