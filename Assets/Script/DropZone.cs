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

        CardDisplay card = d.GetComponent<CardDisplay>();

        // Enough mana to cost
        if (d != null && typeOfCard == d.typeOfCard )
        {

            int needCrystal = card.card.manaCost;
            CrystalManager playercrystal = GameObject.Find("YourCrystal").GetComponent<CrystalManager>();

            Debug.Log(eventData.pointerDrag.name);


            //Current Problematic!
            if (this.transform == GameObject.Find("YourDeck") && card.GetComponentInParent<GameObject>() == GameObject.Find("Hand"))
            {

                if (playercrystal.CostCrystal(needCrystal))
                {
                    Debug.Log("mana cost and moved to deck");
                    d.parentToReturnTo = this.transform;
                }
                else
                {
                    Debug.Log("No enough mana");
                }
            }
            else
            {
                Debug.Log("Not legal area");
            }

            //cost coresspnding mana
        }
    }
}
