using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public enum GameState
{
    GameStarting,
    GetingCards,
    Playcard,
    Pause,
    End
}
public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public GameState gamestate = GameState.GameStarting;

    public float cycletime = 60f;
    public float timer = 0;
    public HandCard handcard;
    public EnermyHand enermycard;

    private TextMeshProUGUI clock;


    private string currentHero = "Player";

    public CardGenerator cardgenerator;


    public int TurnIndex = 0;
    //on switch turns
    public delegate void NewTurnEvent(string heroname);
    public event NewTurnEvent OnNewTurn;

    void Awake()
    {
        _instance = this;
        clock = this.transform.Find("clock").GetComponent<TextMeshProUGUI>();
        clock.gameObject.SetActive(false);
        // Give Cards to Both Heros
        

    }

    private IEnumerator GenerateCardForPlayers()
    {
        //Debug.Log("perfect now");

        GameObject Cardgo = cardgenerator.RandomGetCard("Player");
        yield return new WaitForSeconds(2.1f);
        handcard.GetCard(Cardgo);

        Cardgo = cardgenerator.RandomGetCard("Player");
        yield return new WaitForSeconds(2.1f);
        handcard.GetCard(Cardgo);

        Cardgo = cardgenerator.RandomGetCard("Player");
        yield return new WaitForSeconds(2.1f);
        handcard.GetCard(Cardgo);

        Cardgo = cardgenerator.RandomGetCard("Player");
        yield return new WaitForSeconds(2.1f);
        handcard.GetCard(Cardgo);

        //Give card to enermy
        Cardgo = cardgenerator.RandomGetCard("Enermy");
        yield return new WaitForSeconds(2.1f);
        enermycard.GetCard(Cardgo);

        Cardgo = cardgenerator.RandomGetCard("Enermy");
        yield return new WaitForSeconds(2.1f);
        enermycard.GetCard(Cardgo);

        Cardgo = cardgenerator.RandomGetCard("Enermy");
        yield return new WaitForSeconds(2.1f);
        enermycard.GetCard(Cardgo);

        Cardgo = cardgenerator.RandomGetCard("Enermy");
        yield return new WaitForSeconds(2.1f);
        enermycard.GetCard(Cardgo);

        gamestate = GameState.GetingCards;
        timer = 0;
    }

    void Update()
    {
        if(BlackMask._instance.startgame == true)
        {
            StartCoroutine(GenerateCardForPlayers());
            BlackMask._instance.startgame = false;
        }
        /*
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(GenerateCardForPlayers());
        }
        */

        

        if(gamestate == GameState.GetingCards)
        {
            StartCoroutine(GetTwoCards());
            gamestate = GameState.Pause;
        }
        else if (gamestate == GameState.Playcard)
        {
            if (currentHero == "Player")
            {
                clock.gameObject.SetActive(true);
                int tmp = (int)(60 - timer);
                clock.text = tmp.ToString();

                timer += Time.deltaTime;
                if (timer > cycletime)
                {
                    TransformPlayer();
                }
            }
            else
            {
                timer += Time.deltaTime;

                if (timer > 2f)
                {
                    TransformPlayer();
                }
            }
        }
        
        
    }


    //Switch Player and getcards
    public void TransformPlayer()
    {
        gamestate = GameState.Pause;
        timer = 0;
        if (currentHero == "Player")
        {
            clock.gameObject.SetActive(false);
            currentHero = "Enermy";
        }
        else
        {
            currentHero = "Player";
            

        }
        TurnIndex++; 
        OnNewTurn(currentHero);

        //Give 2 new cards

        //if (TurnIndex >= 2)
        //{
        StartCoroutine(GetTwoCards());
        
        //}

    }

    private IEnumerator GetTwoCards()
    {
        //gamestate = GameState.GetingCards;
        if(currentHero == "Player")
        {
            GameObject Cardgo = cardgenerator.RandomGetCard(currentHero);
            yield return new WaitForSeconds(2.1f);
            handcard.GetCard(Cardgo);

            Cardgo = cardgenerator.RandomGetCard(currentHero);
            yield return new WaitForSeconds(2.1f);
            handcard.GetCard(Cardgo);
        }
        else
        {
            GameObject Cardgo = cardgenerator.RandomGetCard(currentHero);
            yield return new WaitForSeconds(2.1f);
            enermycard.GetCard(Cardgo);

            Cardgo = cardgenerator.RandomGetCard(currentHero);
            yield return new WaitForSeconds(2.1f);
            enermycard.GetCard(Cardgo);
        }
        gamestate = GameState.Playcard;
        timer = 0;
        clock.gameObject.SetActive(true);
    }

    
    

}
