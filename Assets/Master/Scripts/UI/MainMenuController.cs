using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	public GameObject[] items;

	public void updateSelected(BaseEventData eventData){
		print (eventData);
	}

	public void setFirstChildSelected(){
		GameObject menuOption = items[0].gameObject;
		EventSystem.current.SetSelectedGameObject(menuOption, null);
	}

	public void closeAllChildren(){
		foreach(GameObject c in items){
			c.GetComponent<UISelectable>().closeLinkedView();
		}
	}

	public void selectedChild(UISelectable child){
		foreach(GameObject c in items){
			c.GetComponent<UISelectable>().ShowAsInactive();
		}

		child.ShowAsActive();
	}

	public void submit(){
		foreach(GameObject c in items){
			c.GetComponent<UISelectable>().closeLinkedView();
		}

		GameObject selected = EventSystem.current.currentSelectedGameObject;
		selected.GetComponent<UISelectable>().openLinkedView();
	}

}
