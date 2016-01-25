using UnityEngine;
using System.Collections;

public class FireCracker : Prank, Prank.IPrankable {

	public void Trigger() {
		GameObject particle = gameObject.transform.GetChild(0).gameObject;
		particle.GetComponent<ParticleSystem>().Play();
	}
}