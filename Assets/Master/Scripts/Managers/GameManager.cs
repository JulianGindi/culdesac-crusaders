using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	
	public static GameManager instance = null;
	public float playerInfamy;
	public GameObject personObject;

	public GameObject activePlayer; // Player can switch between their two characters

    private PlayerController pc;
    private PlayerMovement pm;
    private AnimationDelegate ad;

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

        pc = personObject.GetComponent<PlayerController>();
        pm = personObject.GetComponent<PlayerMovement>();
        ad = personObject.GetComponent<AnimationDelegate>();
    }

    public void DisableInputForAvatar() {
        pc.enabled = false;
        pm.enabled = false;
        ad.enabled = false;
    }

    public void EnableInputForAvatar()
    {
        pc.enabled = true;
        pm.enabled = true;
        ad.enabled = true;
    }
}