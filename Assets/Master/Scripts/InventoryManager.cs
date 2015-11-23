using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class InventoryManager : MonoBehaviour {

	public static InventoryManager instance = null;
	public int inventorySize;
	public List <GameObject> inventory;
	public List<GameObject> craftingBuffer; // This will hold items from inventory that will be used for crafting
	public GameObject inventoryUI;

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
				UpdateInventoryUI();
			}
		}
	}

	// This function will take what is in the crafting buffer and try to create
	// a prank out of it. If successfull, it will instantiate the prank at the specified
	// location
	public GameObject CraftPrank(string prankName, Transform spawnLocation) {
		GameObject newPrank = new GameObject();

		// Will compare to make sure these items are present int he buffer
		// TODO: Probably figure out a better way to handle these "recipes"
		string[] craftTags = new string[] {"Cyl", "Capsule", "Square"};
		return newPrank;
	}


	// TODO: Rigo implement
	public void UpdateInventoryUI() {

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
