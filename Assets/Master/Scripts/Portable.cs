using UnityEngine;
using System.Collections;

public class Portable : MonoBehaviour {

    public GameObject parentObject;

    void CrossedPortalTo(Portal exit) {
        parentObject.transform.position = exit.GetExitPoint();
    }
}
