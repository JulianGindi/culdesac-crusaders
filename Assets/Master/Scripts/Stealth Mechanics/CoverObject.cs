using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoverObject : MonoBehaviour {

	public GameObject coverIndicator;
	public Transform indicatorPosition;

	public int coverCount = 1; // Number of players this object can cover
	public bool isCovering = false; // Is this object currently covering any player?
	public bool displayCover = false; // Select "true" to automatically display the cover indicator

	List<GameObject> playersCovered; // Reference where we will store the players being covered


	void Start() {
		playersCovered = new List<GameObject>();

		if (displayCover)
			DisplayCoverIndicator();
	}

	bool canCoverAnotherPlayer() {
		return (playersCovered.Count < coverCount);
	}

	public void DisplayCoverIndicator() {
		// Instantiate cover indicator behind object
		Transform spawnLocation; // Middle of object and just slightly behind
		Instantiate(coverIndicator, indicatorPosition.position, Quaternion.identity);
	}

	public void ClearCoveredPlayers() {
		playersCovered.Clear();
	}

	// This function attempts to  add a player to cover.
	// If the "cover is full" the function will return false
	public bool AddPlayerToCover(GameObject player) {
		if (canCoverAnotherPlayer()) {
			playersCovered.Add(player);
			return true;
		}
		return false;
	}
}
