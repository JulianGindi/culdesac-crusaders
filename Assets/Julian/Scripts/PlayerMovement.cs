using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float movementSpeed;

	float horizontalInput;
	float verticalInput;

	Rigidbody playerRB;

	// Use this for initialization
	void Start () {
		playerRB = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		horizontalInput = Input.GetAxis ("Horizontal");
		verticalInput = Input.GetAxis ("Vertical");
	}
}
