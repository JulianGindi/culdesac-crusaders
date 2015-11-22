using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class UISelectable : MonoBehaviour, ISelectHandler, IDeselectHandler, ISubmitHandler {

	protected MainMenuController parentController;
	public GameObject viewToOpen; 

	void Awake(){
		parentController = (MainMenuController) transform.parent.gameObject.GetComponent<MainMenuController>();
	}

    // Event Delegates

	public void OnSubmit (BaseEventData data) 
	{
        SubmitHandler(data);
	}

	public void OnSelect (BaseEventData data) 
	{
        SelectHandler(data);
	}

	public void OnDeselect (BaseEventData data) 
	{
        DeselectHandler(data);
	}

    // Event Handlers

    public virtual void SubmitHandler(BaseEventData data) {
        parentController.submit();
    }

    public virtual void SelectHandler(BaseEventData data) {
        parentController.selectedChild(this);
    }

    public virtual void DeselectHandler(BaseEventData data) {

    }

	public void ShowAsHighlighted(){
        transform.Find("Arrow").gameObject.SetActive(true);
    }

	public void ShowAsUnhighlighted(){
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

    public void closeLinkedView(){
        ShowAsInactive();
		viewToOpen.SetActive(false);
	}

	public void openLinkedView(){
        ShowAsActive();
		viewToOpen.SetActive(true);
	}

}
