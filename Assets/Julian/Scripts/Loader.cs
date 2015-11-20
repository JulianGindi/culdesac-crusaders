using UnityEngine;
using System.Collections;


public class Loader : MonoBehaviour {
	
	public GameObject inventoryManager;
	public GameObject gameManager;
	
	void Awake () {
		if (InventoryManager.instance == null)
			Instantiate(inventoryManager);

		if (GameManager.instance == null)
			Instantiate(gameManager);
	}
}