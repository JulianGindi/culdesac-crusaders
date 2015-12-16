using UnityEngine;
using System.Collections;

public class FireCracker : Prank, Prank.IPrankable {

	public FireCracker(string pName): base(pName) {
		displayName = pName;
	}
	
	public void Trigger() {
		print ("Prank triggering");
	}
}