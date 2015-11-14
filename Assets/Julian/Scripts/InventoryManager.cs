using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class InventoryManager : MonoBehaviour {

	public static InventoryManager instance = null;

	public int inventorySize;

	public List <GameObject> inventory;

	public List<GameObject> craftingBuffer; // This will hold items from inventory that will be used for crafting

	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		DontDestroyOnLoad (gameObject);

		craftingBuffer = new List<GameObject>();
		inventory = new List <GameObject> ();
	}

	public void AddItemToInventory(GameObject item) {
		if (CheckInventorySize()) {
			// We still have room, so we will add the item to the inventory
			if (item) {
				inventory.Add(item);
				item.SetActive(false);
			}
		}
	}

	bool CheckInventorySize() {
		if (inventory.Count > inventorySize)
			return false;
		return true;
	}
	
	void AddCraftableItemsToBuffer(GameObject itemToAdd) {
		craftingBuffer.Add (itemToAdd);
	}	
}
