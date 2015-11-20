using UnityEngine;
using System.Collections;

public class UISelectable : MonoBehaviour {

    public void SetSelected() {
        print("selected");
        GameObject.Find("Image").SetActive(true);
    }
}
