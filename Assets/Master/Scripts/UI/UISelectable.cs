using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class UISelectable : MonoBehaviour, ISelectHandler, IDeselectHandler, ISubmitHandler {

	MainMenuController parentController;
	public GameObject viewToOpen; 

	void Awake(){
		parentController = (MainMenuController) transform.parent.gameObject.GetComponent<MainMenuController>();
	}

	public void OnSubmit (BaseEventData data) 
	{
		parentController.submit();
	}

	public void OnSelect (BaseEventData data) 
	{
		parentController.selectedChild(this);
	}

	public void OnDeselect (BaseEventData data) 
	{

	}

	public void ShowAsActive(){
		transform.Find("Text").gameObject.GetComponent<Shadow>().enabled = true;
	}

	public void ShowAsInactive(){
		transform.Find("Text").gameObject.GetComponent<Shadow>().enabled = false;
	}

	public void closeLinkedView(){
		viewToOpen.SetActive(false);
	}

	public void openLinkedView(){
		viewToOpen.SetActive(true);
	}

}
