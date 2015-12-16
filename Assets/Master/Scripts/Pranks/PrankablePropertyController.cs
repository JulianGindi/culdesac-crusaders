using UnityEngine;
using System.Collections;

public class PrankablePropertyController : MonoBehaviour {

	void OnCollisionEnter (Collision collision) {
		if (collision.collider.CompareTag("Prank")) {
			GameManager.instance.playerInfamy += 1f;
		}
	}
}
