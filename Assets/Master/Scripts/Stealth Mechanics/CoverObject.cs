using UnityEngine;
using System.Collections;

public class CoverObject : MonoBehaviour {

	public GameObject coverIndicator;
	public Transform indicatorPosition;

	public int coverCount = 1; // Number of players this object can cover
	public bool isCovering = false; // Is this object currently covering any player?

	GameObject playerObject; // Reference where we will store the closest player
	bool isIndicating; // Don't keep indicating if already indicating
	int playersCovered;

	void Start() {
		playersCovered = 0;
		isIndicating = false;
	}

	void Update() {
		if (playerNearby() && canCoverAnotherPlayer() && !isIndicating) {
			displayCoverIndicator();
			isIndicating = true;
		}
	}

	bool playerNearby() {
		// We basically want to know if there is another "cover object" 
		// in between this object and the player
		return true;
	}

	bool canCoverAnotherPlayer() {
		return (playersCovered < coverCount);
	}

	void displayCoverIndicator() {
		// Instantiate cover indicator behind object
		Transform spawnLocation; // Middle of object and just slightly behind
		Instantiate(coverIndicator, indicatorPosition.position, Quaternion.identity);
	}
}
