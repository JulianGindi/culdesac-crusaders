using UnityEngine;
using System.Collections;

public class Portable : MonoBehaviour {

    public GameObject parentObject;

    void CrossedPortalTo(Portal exit) {
		print ("INSIDE CROSSEDPORTALTO");
		parentObject.GetComponent<PlayerMovement>().isOutside = false;
        parentObject.transform.position = exit.GetExitPoint();
    }
}
