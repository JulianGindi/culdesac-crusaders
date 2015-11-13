using UnityEngine;
using System.Collections;


public class Loader : MonoBehaviour {
	
	public GameObject inventoryManager;
	
	void Awake () {
		if (InventoryManager.instance == null)
			Instantiate(inventoryManager);
	}
}