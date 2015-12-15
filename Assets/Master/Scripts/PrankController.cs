using UnityEngine;
using System.Collections;

public class PrankController : MonoBehaviour {

	public static PrankController instance = null;
	public GameObject personObject;

	// A public list of currently-active Pranks
	public Prank[] activePranks;

	public class Prank: MonoBehaviour {
		public string name;

		public Prank(string name) {
			name = name;
		}
	}
	

	public interface IPrankable {
		// This is a function that MUST be implemented by any prank class
		void Trigger();
	}

	public class FireCracker: Prank, IPrankable {
		public void Trigger() {
			print ("Prank triggering");
		}
	}
	

	// Boilerplate static GameManager stuff
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		DontDestroyOnLoad (gameObject);
	}
	
	void Start() {

	}
}
