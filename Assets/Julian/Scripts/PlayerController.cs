using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	bool inObjectRange;
	GameObject itemToPickup;

	void Update() {
		if (Input.GetKey ("e")) {
			// Add item to inventory
			inObjectRange = false;
			InventoryManager.instance.AddItemToInventory(itemToPickup);
			itemToPickup = null;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Item")) {
			inObjectRange = true;
			itemToPickup = other.gameObject;
			print("Press e to pickup item");
		}
	}
}
