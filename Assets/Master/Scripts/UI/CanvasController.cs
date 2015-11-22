using UnityEngine;
using System.Collections;

public class CanvasController : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject Inventory;
    private bool isButtonPressed;
	public UnityEngine.EventSystems.EventSystem eventSystem;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Cancel") > 0)
        {
            if (!isButtonPressed) {
				MainMenu.SetActive(!MainMenu.activeInHierarchy);

				if(MainMenu.activeInHierarchy){
					MainMenu.GetComponent<MainMenuController>().setFirstChildSelected();
				}
				} else {
					MainMenu.GetComponent<MainMenuController>().closeAllChildren();
				}

            isButtonPressed = true;
        }
        else {
            isButtonPressed = false;
        }
    }
}
