﻿using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

	public GameObject[] items;

    void Start() {
        closeAllChildren();
        gameObject.SetActive(false);
    }

    public void disableAllSelectableChildren() {
        foreach (GameObject c in items)
        {
            c.GetComponent<Selectable>().enabled = false;
        }
    }

    public void enableAllSelectableChildren()
    {
        foreach (GameObject c in items)
        {
            c.GetComponent<Selectable>().enabled = true;
        }
    }

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
			c.GetComponent<UISelectable>().ShowAsUnhighlighted();
        }

		child.ShowAsHighlighted();
    }

	public void submit(){
		foreach(GameObject c in items){
			c.GetComponent<UISelectable>().closeLinkedView();
		}

		GameObject selected = EventSystem.current.currentSelectedGameObject;
		selected.GetComponent<UISelectable>().openLinkedView();
        disableAllSelectableChildren();
    }

}
