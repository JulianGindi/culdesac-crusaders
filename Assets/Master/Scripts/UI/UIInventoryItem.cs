using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class UIInventoryItem : UISelectable
{
    public string ItemID;

    public override void SubmitHandler(BaseEventData data)
    {
        print("Selected item " + ItemID);
    }

    public override void SelectHandler(BaseEventData data)
    {
        print("Highlighted item " + ItemID);
    }

}
