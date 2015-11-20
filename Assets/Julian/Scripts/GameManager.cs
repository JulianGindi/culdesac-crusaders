using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	
	public static GameManager instance = null;

	public float playerInfamy;
	public GameObject personObject;


	// Boilerplate static GameManager stuff
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		DontDestroyOnLoad (gameObject);
	}
	
	void Start() {
		playerInfamy = 0f;
	}
}