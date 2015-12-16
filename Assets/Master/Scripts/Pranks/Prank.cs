﻿using UnityEngine;
using System.Collections;

public class Prank : MonoBehaviour {
	public string displayName;

	public interface IPrankable {
		// This is a function that MUST be implemented by any prank class
		void Trigger();
	}

	public Prank(string pName) {
		displayName = pName;
	}
}