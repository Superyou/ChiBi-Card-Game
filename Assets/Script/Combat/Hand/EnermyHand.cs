using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyHand : MonoBehaviour
{

    private List<GameObject> cardList = new List<GameObject>();
    public Transform endcard;

    public void GetCard(GameObject Cardgo)
    {
        GameObject go=null;
        go = Cardgo;
        go.transform.parent = this.transform;

        

        go.transform.localScale = new Vector3(0.37f, 0.37f, 0.37f);



        //Cartoon for add into hand 
        //iTween.MoveTo(go, cardend.position, 1f);
        //go.transform.parent = this.transform;

        cardList.Add(go);

    }

}
