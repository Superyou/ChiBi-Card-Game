using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCard : MonoBehaviour
{

    public GameObject cardPrefab;
    public Transform cardstart;
    public Transform cardend;

    private List<GameObject> CardinHand = new List<GameObject>();


    



    public void GetCard(GameObject Cardgo = null)
    {
        GameObject go = null;
        if (Cardgo == null)
        {
            go = NGUITools.AddChild(this.gameObject, cardPrefab);

        }
        else
        {
            
            go = Cardgo;
            go.transform.parent = this.transform;

        }

        go.transform.localScale = new Vector3(0.37f, 0.37f, 0.37f);
        


        //Cartoon for add into hand 
        //iTween.MoveTo(go, cardend.position, 1f);
        //go.transform.parent = this.transform;
        
        CardinHand.Add(go);


    }

    public void TakeCard()
    {
        int index = Random.Range(0, CardinHand.Count);
        Destroy(CardinHand[index]);
        CardinHand.RemoveAt(index);
    }


    //handle it with Deck Zone
    public void RemoveFromHand(GameObject go)
    {
        CardinHand.Remove(go);
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            GetCard();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            TakeCard();
        }
        
    }
}