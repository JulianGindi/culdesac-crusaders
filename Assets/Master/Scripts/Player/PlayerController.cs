using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject spawnLocationObj;
    public GameObject projectileToSpawn;
	public float launchForce = 1000f;
	public float launchAngle = 30.0f;

	GameObject prankToAdd;

	void Update() {
        if (Input.GetButtonDown("Throw")) {
            ThrowCurrentPrank();
        }

        if (Input.GetButtonDown("Pickup/Place"))
        {
            if (prankToAdd != null)
            {
                Pickup();
            }
            else {
                PlaceCurrentPrank();
            }
        }
    }

    void Pickup() {
        if (prankToAdd != null) {
            // Add item to inventory
            PrankManager.instance.AddPrankToActive(prankToAdd);
            prankToAdd = null;
        }
    }

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Contains ("Prank")) {
			prankToAdd = other.gameObject;
		}
	}

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Contains("Prank"))
        {
            prankToAdd = null;
        }
    }

    void PlaceCurrentPrank() {
        if (PrankManager.instance.activePrank != null) {
            // Now we will create an instance of whatever the 'current prank' is
            GameObject placedPrank = Instantiate(PrankManager.instance.activePrank, spawnLocationObj.transform.position, Quaternion.identity) as GameObject;
			placedPrank.SetActive(true);
            placedPrank.SendMessage("Trigger");
        }
	}

    void ThrowCurrentPrank() {
        if (PrankManager.instance.activePrank != null) {
            // calculate the elevation vector:
            Vector3 forwards = transform.forward; // get the forward direction
            Vector3 dir = new Vector3(forwards.x, 0f, forwards.z); // keep it in the horizontal plane
            Vector3 norm = dir.normalized;
            norm.y = Mathf.Sin(launchAngle * Mathf.Deg2Rad); // set the desired elevation angle

            // Now we will create an instance of whatever the 'current prank' is
            GameObject thrownObject = Instantiate(PrankManager.instance.activePrank, spawnLocationObj.transform.position, transform.rotation) as GameObject;
            thrownObject.SetActive(true);
            thrownObject.GetComponent<Rigidbody>().velocity = launchForce * norm.normalized;

            thrownObject.SendMessage("Trigger");
        }
    }

	void DropSmokeBomb() {

	}

}