using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;

public class UIInventoryMenu : UIMenu {

    public GameObject Grid;
    public Transform uiElement;
    public GameObject firstSelected;

	// Grab a copy of inventoryManager

    public void RefreshAllItems(List<GameObject> inventory) {
        RemoveAllItems();
        AddAllItems(inventory);
    }

    public void AddAllItems(List<GameObject> inventory)
    {
        int count = 0;
        foreach (GameObject child in inventory)
        {
            Transform newElement = Instantiate(uiElement);
            newElement.SetParent(Grid.transform);
            if (count == 0) {
                firstSelected = newElement.gameObject;
            }

            count++;
        }
    }

    private void RemoveAllItems() {
        Transform pt = Grid.transform;
        foreach (Transform child in pt)
        {
            Destroy(child.gameObject);
        }
    }

    public override void setDefaultSelectedItem()
    {
        EventSystem.current.SetSelectedGameObject(firstSelected, null);
    }

}
