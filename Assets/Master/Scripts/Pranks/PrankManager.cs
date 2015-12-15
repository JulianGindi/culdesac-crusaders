using UnityEngine;
using System.Collections;

public class PrankManager : MonoBehaviour {

	public static PrankManager instance = null;
	public GameObject personObject;

	// A public list of currently-available Pranks
	public Prank[] availablePranks;

	// We also want to know which prank is currently "active"
	public Prank activePrank;


	// Boilerplate static GameManager stuff
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		DontDestroyOnLoad (gameObject);
	}
	
	void Start() {
		// For testing, we are making the active prank the first one
		activePrank = availablePranks[0];
	}
}
