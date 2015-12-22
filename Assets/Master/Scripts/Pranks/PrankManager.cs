using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PrankManager : MonoBehaviour {

	public static PrankManager instance = null;
	public GameObject personObject;
    public GameObject UI_ActivePrank;

    // A public list of currently-available Pranks
    public List <GameObject> availablePranks;

	// We also want to know which prank is currently "active"
	public GameObject activePrank;
	
	// Boilerplate static Manager stuff
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		DontDestroyOnLoad (gameObject);
	}

	public void AddPrankToActive(GameObject prankToAdd) {
		availablePranks.Add(prankToAdd);

        // disables the picked up one... we should also remove it from the scene, but that requires cloning it first?
        prankToAdd.SetActive(false); 

        // Immediately switch to the item you just picked up
        if (availablePranks.Count >= 1) {
            activePrank = prankToAdd;
            Prank ap = activePrank.GetComponent<Prank>();
            Sprite icon = ap.UI_icon;
            UI_ActivePrank.GetComponent<Image>().sprite = icon;
            UI_ActivePrank.SetActive(true);
        }
    }

	public void SwitchPrank() {
		if (availablePranks.Count > 1) {
			int currentPrankIndex = availablePranks.IndexOf(activePrank);
			int newPrankIndex = currentPrankIndex += 1;

			if (newPrankIndex > availablePranks.Count) {
				activePrank = availablePranks[0];
			} else {
				activePrank = availablePranks[newPrankIndex];
			}
		}
	}
}
