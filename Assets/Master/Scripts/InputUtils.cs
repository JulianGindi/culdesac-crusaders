using UnityEngine;
using System.Collections;

public delegate void OnKeyPress();
public delegate void OnKeyRelease();

public class InputUtils : MonoBehaviour {

    private bool respondedToButtonPress;
    private bool respondedToButtonRelease;

    public void AxisToActionEvent(string axisName, OnKeyPress keyPressHandler, OnKeyRelease keyReleaseHandler) {
        if (Input.GetAxis(axisName) > 0)
        {
            if (!respondedToButtonPress)
            {
                keyPressHandler();
            }
            respondedToButtonPress = true;
            respondedToButtonRelease = false;
        }
        else
        {
            if (!respondedToButtonRelease)
            {
                keyReleaseHandler();
            }
            respondedToButtonPress = false;
            respondedToButtonRelease = true;
        }
    }

}
