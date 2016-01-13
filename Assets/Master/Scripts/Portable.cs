using UnityEngine;
using System.Collections;

public class Portable : MonoBehaviour {

    public GameObject parentObject;

    void CrossedPortalTo(Portal exit) {
		parentObject.GetComponent<PlayerMovement>().isOutside = false;
        parentObject.transform.position = exit.GetExitPoint();
    }
}
