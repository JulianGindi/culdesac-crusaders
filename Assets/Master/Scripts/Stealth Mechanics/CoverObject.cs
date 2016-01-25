using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoverObject : MonoBehaviour {

	public GameObject coverIndicator;
	public Transform indicatorPosition;

	public int coverCount = 1; // Number of players this object can cover
	public bool isCovering = false; // Is this object currently covering any player?

	List<GameObject> playersCovered; // Reference where we will store the players being covered
	bool isIndicating; // Don't keep indicating if already indicating

	List<GameObject> playersInRange; // Players who can seek cover but have not yet

	void Start() {
		isIndicating = false;

		playersCovered = new List<GameObject>();
		playersInRange = new List<GameObject>();

	}

	void Update() {
		if ((playersInRange.Count > 0) && canCoverAnotherPlayer() && !isIndicating) {
			displayCoverIndicator();
			isIndicating = true;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player"))
			playersInRange.Add(other.gameObject);
	}

	void displayCoverIndicator() {
		// Instantiate cover indicator behind object
		Transform spawnLocation; // Middle of object and just slightly behind
		Instantiate(coverIndicator, indicatorPosition.position, Quaternion.identity);
	}
		
	bool canCoverAnotherPlayer() {
		return (playersCovered.Count < coverCount);
	}
}
