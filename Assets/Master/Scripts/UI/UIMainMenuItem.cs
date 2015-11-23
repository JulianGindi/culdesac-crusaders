using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIMainMenuItem : UISelectableItem
{

    protected UIMainMenu parentController;

    void Awake()
    {
        parentController = (UIMainMenu)transform.parent.gameObject.GetComponent<UIMainMenu>();
    }

    public override void SubmitHandler(BaseEventData data)
    {
        parentController.submit();
    }

    public override void SelectHandler(BaseEventData data)
    {
        parentController.selectedChild(this);
    }

    public override void DeselectHandler(BaseEventData data)
    {

    }

    public void ShowAsHighlighted()
    {
        transform.Find("Arrow").gameObject.SetActive(true);
    }

    public void ShowAsUnhighlighted()
    {
        transform.Find("Arrow").gameObject.SetActive(false);
    }

    public void ShowAsActive()
    {
        transform.Find("Text").gameObject.GetComponent<Shadow>().enabled = true;
        transform.Find("Arrow").gameObject.GetComponent<Shadow>().enabled = true;
    }

    public void ShowAsInactive()
    {
        transform.Find("Text").gameObject.GetComponent<Shadow>().enabled = false;
        transform.Find("Arrow").gameObject.GetComponent<Shadow>().enabled = false;
    }

    public void closeLinkedView()
    {
        ShowAsInactive();
        viewToOpen.gameObject.SetActive(false);
    }

    public void openLinkedView()
    {
        ShowAsActive();
        viewToOpen.gameObject.SetActive(true);
        viewToOpen.setDefaultSelectedItem();
    }

}
