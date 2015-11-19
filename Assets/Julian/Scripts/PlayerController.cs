using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Rigidbody baseball;
	public Transform spawnLocation;
	public float launchForce = 1000f;
	public float launchAngle = 30.0f;

	bool inObjectRange;
	GameObject itemToPickup;

	void Start() {
		inObjectRange = false;
	}

	void Update() {
		if (Input.GetKey ("e") && inObjectRange) {
			// Add item to inventory
			inObjectRange = false;
			InventoryManager.instance.AddItemToInventory(itemToPickup);
			itemToPickup = null;
		} else if (Input.GetKeyDown ("q")) {
			// Throw Object...for now a baseball
			ThrowBall();
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Item")) {
			inObjectRange = true;
			itemToPickup = other.gameObject;
			print("Press e to pickup item");
		}
	}

	void ThrowBall() {
		// calculate the elevation vector:
		Vector3 forwards = transform.forward; // get the forward direction
		Vector3 dir = new Vector3(forwards.x, 0f, forwards.z); // keep it in the horizontal plane
		Vector3 norm = dir.normalized;
		norm.y = Mathf.Sin(launchAngle * Mathf.Deg2Rad); // set the desired elevation angle

		Rigidbody thrownBall = Instantiate(baseball, spawnLocation.position, transform.rotation) as Rigidbody;
		thrownBall.velocity = launchForce * norm.normalized;
    }
}