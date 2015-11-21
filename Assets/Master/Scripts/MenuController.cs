using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject Inventory;
    private bool isButtonPressed;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Submit") > 0)
        {
            if (!isButtonPressed) {
                MainMenu.active = !MainMenu.active;
            }
            isButtonPressed = true;
        }
        else {
            isButtonPressed = false;
        }
    }
}
