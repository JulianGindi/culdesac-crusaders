using UnityEngine;
using System.Collections;


public class Loader : MonoBehaviour {
	
	public GameObject inventoryManager;
	public GameObject gameManager;
	public GameObject prankManager;
	
	void Awake () {
		if (InventoryManager.instance == null)
			Instantiate(inventoryManager);

		if (GameManager.instance == null)
			Instantiate(gameManager);

		if (PrankManager.instance == null)
			Instantiate(prankManager);

		// Target 60fps
		Application.targetFrameRate = 60;
	}
}