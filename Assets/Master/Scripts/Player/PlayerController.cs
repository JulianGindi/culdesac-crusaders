using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject spawnLocationObj;
    public GameObject projectileToSpawn;
	public float launchForce = 1000f;
	public float launchAngle = 30.0f;

	bool inPrankRange;
	GameObject prankToAdd;

	void Start() {
		inPrankRange = false;
    }

	void Update() {
        if (Input.GetButtonDown("Throw")) {
            print("throw");
            ThrowCurrentPrank();
        }
        if (Input.GetButtonDown("Place"))
        {
            print("place");
            PlaceCurrentPrank();
        }
        if (Input.GetButtonDown("Pickup"))
        {
            print("Pickup");
            Pickup();
        }
    }

    void Pickup() {
        if (prankToAdd != null) {
            // Add item to inventory
            inPrankRange = false;
            PrankManager.instance.AddPrankToActive(prankToAdd);
            prankToAdd = null;
        }
    }

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Contains ("Prank")) {
			inPrankRange = true;
			prankToAdd = other.gameObject;
			print("Press e to pickup item");
		}
	}

	void PlaceCurrentPrank() {
		// Now we will create an instance of whatever the 'current prank' is
		GameObject placedPrank = Instantiate(PrankManager.instance.activePrank, spawnLocationObj.transform.position, Quaternion.identity) as GameObject;
		placedPrank.SetActive(true);
		// TODO: Figure out how to do this whole trigger thingy
		placedPrank.SendMessage("Trigger");
		//placedPrank.Trigger();
	}

    void ThrowCurrentPrank() {
        print("Throw Current Prank");
        // calculate the elevation vector:
        Vector3 forwards = transform.forward; // get the forward direction
        Vector3 dir = new Vector3(forwards.x, 0f, forwards.z); // keep it in the horizontal plane
        Vector3 norm = dir.normalized;
        norm.y = Mathf.Sin(launchAngle * Mathf.Deg2Rad); // set the desired elevation angle

        // Now we will create an instance of whatever the 'current prank' is
        GameObject thrownObject = Instantiate(PrankManager.instance.activePrank, spawnLocationObj.transform.position, transform.rotation) as GameObject;
        thrownObject.SetActive(true);
        thrownObject.GetComponent<Rigidbody>().velocity = launchForce * norm.normalized;

        // TODO: Figure out how to do this whole trigger thingy
        thrownObject.SendMessage("Trigger");
    }

	void UseOrThrow() {
        
    }
}