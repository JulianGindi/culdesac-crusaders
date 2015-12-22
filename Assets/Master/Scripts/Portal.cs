using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

    public GameObject exitPortal;

    Vector3 exitPoint;

    void Awake() {
        exitPoint = transform.Find("Exit Point").transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        other.SendMessage("CrossedPortalTo", exitPortal.GetComponent<Portal>());
    }

    public Vector3 GetExitPoint() {
        return exitPoint;
    }

}
