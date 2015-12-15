using UnityEngine;
using System.Collections;

public class FireCracker : Prank, Prank.IPrankable {

	public FireCracker(string name): base(name) {
		name = name;
	}
	
	public void Trigger() {
		print ("Prank triggering");
	}
}