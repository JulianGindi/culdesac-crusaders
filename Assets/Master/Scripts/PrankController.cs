using UnityEngine;
using System.Collections;

public class PrankController : MonoBehaviour {

	public class Prank {

		public string name;
		public string type; // Projectile, 'bomb', aoe, graffitti...

		public Prank(string prankName, string prankType) {
			name = prankName;
			type = prankType;
		}

	}
}
