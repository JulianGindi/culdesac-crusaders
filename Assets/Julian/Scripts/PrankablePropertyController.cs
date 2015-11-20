using UnityEngine;
using System.Collections;

public class PrankablePropertyController : MonoBehaviour {

	void OnCollisionEnter (Collision collision) {
		if (collision.collider.CompareTag("Baseball")) {
			GameManager.instance.playerInfamy += 1f;
		}
	}
}
