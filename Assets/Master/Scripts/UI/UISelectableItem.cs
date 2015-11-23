using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class UISelectableItem : MonoBehaviour, ISelectHandler, IDeselectHandler, ISubmitHandler {

	public UIMenu viewToOpen;

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
    }

    public virtual void SelectHandler(BaseEventData data) {
    }

    public virtual void DeselectHandler(BaseEventData data) {
    }
    
}
