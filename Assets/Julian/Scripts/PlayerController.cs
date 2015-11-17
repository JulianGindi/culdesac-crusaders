using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	bool inObjectRange;
	GameObject itemToPickup;

	void Start() {
		inObjectRange = false;
	}

	void Update() {
		if (Input.GetKey ("e") && inObjectRange) {
			// Add item to inventory
			inObjectRange = false;
			InventoryManager.instance.AddItemToInventory(itemToPickup);
			itemToPickup = null;
		} else if (Input.GetKey ("q")) {
			// Throw Object...for now a baseball
			ThrowObject();
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Item")) {
			inObjectRange = true;
			itemToPickup = other.gameObject;
			print("Press e to pickup item");
		}
	}

	void ThrowObject() {

	}
}
