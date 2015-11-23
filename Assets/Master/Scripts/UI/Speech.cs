using UnityEngine;
using System.Collections;

public class Speech : MonoBehaviour {

    public GameObject speechCanvas;
    private InputUtils inputUtils;

	// Use this for initialization
	void Start () {
        inputUtils = gameObject.AddComponent<InputUtils>();
	}
	
	// Update is called once per frame
	void Update () {
        inputUtils.AxisToActionEvent("Submit", RespondToButtonPress, RespondToButtonRelease);
    }

    void RespondToButtonPress() {
        print("RespondToButtonPress");
    }

    void RespondToButtonRelease() {
        print("RespondToButtonRelease");
    }
}
