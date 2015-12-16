using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PrankManager : MonoBehaviour {

	public static PrankManager instance = null;
	public GameObject personObject;

	// A public list of currently-available Pranks
	public List <GameObject> availablePranks;

	// We also want to know which prank is currently "active"
	public GameObject activePrank;
	
	// Boilerplate static Manager stuff
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		DontDestroyOnLoad (gameObject);
	}

	public void AddPrankToActive(GameObject prankToAdd) {
		availablePranks.Add(prankToAdd);

		if (availablePranks.Count == 1)
			activePrank = availablePranks[0];
	}

	public void SwitchPrank() {
		if (availablePranks.Count > 1) {
			int currentPrankIndex = availablePranks.IndexOf(activePrank);
			int newPrankIndex = currentPrankIndex += 1;

			if (newPrankIndex > availablePranks.Count) {
				activePrank = availablePranks[0];
			} else {
				activePrank = availablePranks[newPrankIndex];
			}
		}
	}
}
