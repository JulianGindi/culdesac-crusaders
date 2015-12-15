using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private InputUtils inputUtils;

    public GameObject spawnLocationObj;
    public GameObject projectileToSpawn;
	public float launchForce = 1000f;
	public float launchAngle = 30.0f;

	bool inObjectRange;
	GameObject itemToPickup;

	void Start() {
		inObjectRange = false;
        inputUtils = gameObject.AddComponent<InputUtils>();
    }

	void Update() {
        inputUtils.AxisToActionEvent("Fire1", ThrowCurrentPrank, null);
    }

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Contains ("Item")) {
			inObjectRange = true;
			itemToPickup = other.gameObject;
			print("Press e to pickup item");
		}
	}

	void ThrowCurrentPrank() {
		// calculate the elevation vector:
		Vector3 forwards = transform.forward; // get the forward direction
		Vector3 dir = new Vector3(forwards.x, 0f, forwards.z); // keep it in the horizontal plane
		Vector3 norm = dir.normalized;
		norm.y = Mathf.Sin(launchAngle * Mathf.Deg2Rad); // set the desired elevation angle

		// Now we will create an instance of whatever the 'current prank' is


        GameObject thrownProjectile = Instantiate(projectileToSpawn, spawnLocationObj.transform.position, transform.rotation) as GameObject;
		thrownProjectile.GetComponent<Rigidbody>().velocity = launchForce * norm.normalized;
    }
}