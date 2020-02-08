using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public enum GameState
{
    GameStarting, 
    Playcard,
    End
}
public class GameManager : MonoBehaviour
{
    public GameState gamestate = GameState.GameStarting;

    public float cycletime = 60f;
    public float timer = 0;

    private TextMeshProUGUI clock;

    void Awake()
    {
        clock = this.transform.Find("clock").GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RandomGetCard();
        }
        if (isTransforming)
        {
            timer += Time.deltaTime;
            int index =(int)(timer / (1f / transformSpeed));
            index %= cardsLab.Length;
            //currentCard.SetCard(cardsLab[index]);


            if (timer > transformTime)
            {
                timer = 0;
                isTransforming = false;
            }
        }
        if (gamestate == GameState.Playcard)
        {
            clock.gameObject.SetActive(true);
            int tmp = (int)(60 - timer);
            clock.text = tmp.ToString();

            timer += Time.deltaTime;
            if(timer > cycletime)
            {
                TransformPlayer();
            }
        }
        
        
    }

    private void TransformPlayer()
    {

    }

    public GameObject cardPrefab;
    public Transform fromcard;
    public Transform tocard;
    public Card[] cardsLab;

    //private CardDisplay currentCard;

    //private float timer;
    public float transformTime = 2f;
    public int transformSpeed = 20;

    private bool isTransforming = false;

    public void RandomGetCard()
    {
        isTransforming = true;
        GameObject go = NGUITools.AddChild(this.gameObject, cardPrefab);
        go.transform.position = fromcard.position;
        //currentCard = go.GetComponent<CardDisplay>();
        iTween.MoveTo(go, tocard.position, 1f);
    }
    

}
