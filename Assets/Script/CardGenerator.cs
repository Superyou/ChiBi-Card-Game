using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    //The template of the card
    public GameObject cardPrefab;

    public Transform fromcard;
    public Transform tocard;
    public Transform targetcard;
    public Transform target2card;

    //All the cards we are going to use in the game
    public Card[] cardsLab;

    //In order to change the card assets to display on go
    private CardDisplay currentCard;

    private float timer = 0;
    public float transformTime = 2f;
    public int transformSpeed = 20;

    private bool isTransforming = false;

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RandomGetCard("Player");
        }
        if (isTransforming)
        {
            timer += Time.deltaTime;
            if (timer > transformTime)
            {
                timer = 0;
                isTransforming = false;
            }
        }
        
        


    }


    public GameObject RandomGetCard(string heroname)
    {
        Debug.Log("Start random GO");

        GameObject go = NGUITools.AddChild(this.gameObject, cardPrefab);
        go.transform.position = fromcard.position;
        go.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        currentCard = go.GetComponent<CardDisplay>();
        currentCard.SetCard(cardsLab[Random.Range(0, cardsLab.Length)]);
        //iTween.MoveTo(go, tocard.position, 3f);

        if (heroname == "Player")
        {
            StartCoroutine(MovetoPlayer(go));
        }
        else
        {
            StartCoroutine(MovetoEnermy(go));
        }
        //isTransforming = true;
        //Debug.Log("created random GO");

        return go;
    }

    private IEnumerator MovetoPlayer(GameObject x)
    {
        iTween.MoveTo(x, tocard.position, 2f);
        yield return new WaitForSeconds(1f);
        iTween.MoveTo(x, targetcard.position, 1f);
        iTween.ScaleTo(x,new Vector3(0.37f,0.37f,0.37f), 1f);
        
    }

    private IEnumerator MovetoEnermy(GameObject x)
    {
        iTween.MoveTo(x, tocard.position, 2f);
        yield return new WaitForSeconds(1f);
        iTween.MoveTo(x, target2card.position, 1f);
        iTween.ScaleTo(x, new Vector3(0.37f, 0.37f, 0.37f), 1f);

    }



}
