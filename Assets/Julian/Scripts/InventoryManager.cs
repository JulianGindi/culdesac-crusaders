using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class InventoryManager : MonoBehaviour {

	public static InventoryManager instance = null;

	public int inventorySize;

	public List <GameObject> inventory;

	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		DontDestroyOnLoad (gameObject);

		inventory = new List <GameObject> ();
	}

	public void AddItemToInventory(GameObject item) {
		if (CheckInventorySize()) {
			// We still have room, so we will add the item to the inventory
			if (item) {
				inventory.Add(item);
				Destroy(item);
			}
		}
	}

	bool CheckInventorySize() {
		if (inventory.Count > inventorySize)
			return false;
		return true;
	}
}
