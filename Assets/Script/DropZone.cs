using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{

    public Draggable.CardType typeOfCard = Draggable.CardType.HERO;

    public void OnDrop(PointerEventData eventData)
    {
        //eventData.pointerDrag is the object being dragged
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>(); //d is the object being dragged

        if (d != null && typeOfCard == d.typeOfCard )
        {
            d.parentToReturnTo = this.transform;
        }
    }
}
