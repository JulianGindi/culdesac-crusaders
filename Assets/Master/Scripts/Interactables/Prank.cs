using UnityEngine;
using System.Collections;
using System;

public class Prank : MonoBehaviour {
	public string displayName;
    public Sprite UI_icon;

    protected bool isActive = false;

	public interface IPrankable {
		// This is a function that MUST be implemented by any prank class
		void Trigger();
	}
}