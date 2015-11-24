using UnityEngine;
using System.Collections;

public class AIVision : MonoBehaviour {
	
	[HideInInspector] // We don't want to see this in the editor...just want to be able to access it
	public bool playerInSight;


	void Start() {
		playerInSight = false;
	}


	void OnTriggerStay(Collider other) {

		if (other.CompareTag("Player")) {
			print ("Camera saw player");
			playerInSight = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.CompareTag("Player"))
			playerInSight = false;
	}
}
