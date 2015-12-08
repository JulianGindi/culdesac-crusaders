using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class InventoryManager : MonoBehaviour {

	public static InventoryManager instance = null;
	public int inventorySize;
	public List <GameObject> inventory;
	public GameObject inventoryUI;

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
				item.SetActive(false);
				UpdateInventoryUI();
			}
		}
	}
	
	public GameObject CraftPrank(string prankName, Transform spawnLocation) {

		GameObject newPrank = new GameObject();
		return newPrank;
	}

	public void RespondToCraftEvent() {
		FindMatchingPranks();
	}
	
	public void UpdateInventoryUI() {
        UIInventoryMenu inventoryMenu = inventoryUI.GetComponent<UIInventoryMenu>();
        inventoryMenu.RefreshAllItems(inventory);
    }

	//GameObject[] FindMatchingPranks() {
	void FindMatchingPranks() {
		// First we will get all the items in our inventory
		// Than we will see if they match any in our given "recipes"
		string[] testRecipe = new string[] {"Cyl", "Capsule", "Square"};
		GetInventoryTagString();
	}

	string GetInventoryTagString() {
		foreach (var item in inventory) {
			print(item);
		}
		return "foo";
	}

	bool CheckInventorySize() {
		if (inventory.Count > inventorySize)
			return false;
		return true;
	}
}
