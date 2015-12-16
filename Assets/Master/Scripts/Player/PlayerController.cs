using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private InputUtils inputUtils;

    public GameObject spawnLocationObj;
    public GameObject projectileToSpawn;
	public float launchForce = 1000f;
	public float launchAngle = 30.0f;

	bool inPrankRange;
	GameObject prankToAdd;

	void Start() {
		inPrankRange = false;

		if (Input.GetKey ("e") && inPrankRange) {
			// Add item to inventory
			inPrankRange = false;
			PrankManager.instance.AddPrankToActive(prankToAdd);
			prankToAdd = null;
		}

        inputUtils = gameObject.AddComponent<InputUtils>();
    }

	void Update() {
        inputUtils.AxisToActionEvent("Fire1", ThrowCurrentPrank, null);
    }

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Contains ("Prank")) {
			inPrankRange = true;
			prankToAdd = other.gameObject;
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


        GameObject thrownObject = Instantiate(PrankManager.instance.activePrank, spawnLocationObj.transform.position, transform.rotation) as GameObject;
		thrownObject.GetComponent<Rigidbody>().velocity = launchForce * norm.normalized;
    }
}