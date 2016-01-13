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
		// We should check here to make sure it is a player
		if (other.CompareTag("Player")) {
        	other.SendMessage("CrossedPortalTo", exitPortal.GetComponent<Portal>(), SendMessageOptions.DontRequireReceiver);
			other.GetComponent<PlayerMovement>().isOutside = false;
		}
    }

    public Vector3 GetExitPoint() {
        return exitPoint;
    }

}
