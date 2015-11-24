using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CanvasController : MonoBehaviour {

    public EventSystem eventSystem;
    public GameObject MainMenu;
    public GameObject Inventory;

    private bool respondedToButtonPress;
    private GameManager gm;

    // Use this for initialization
    void Start () {
        gm = FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Cancel") > 0)
        {
            if (!respondedToButtonPress) {
                RespondToButtonPress();
			}
            respondedToButtonPress = true;
        }
        else {
            respondedToButtonPress = false;
        }
    }

    void RespondToButtonPress() {

        MainMenu.SetActive(!MainMenu.activeInHierarchy);
        if (MainMenu.activeInHierarchy)
        {
            // If we're opening the main menu, pre-highlight the first option.
            MainMenu.GetComponent<UIMainMenu>().setFirstChildSelected();
            MainMenu.GetComponent<UIMainMenu>().enableAllSelectableChildren();
            gm.DisableInputForAvatar();
        } else
        {
            // If we're closing the main menu. close all children too.
            MainMenu.GetComponent<UIMainMenu>().closeAllChildren();
            MainMenu.GetComponent<UIMainMenu>().disableAllSelectableChildren();
            gm.EnableInputForAvatar();
        }
    }

}
