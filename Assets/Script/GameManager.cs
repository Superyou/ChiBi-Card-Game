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
    public HandCard handcard;


    private TextMeshProUGUI clock;


    private string currentHero = "hero1";

    public CardGenerator cardgenerator;

    

    void Awake()
    {
        clock = this.transform.Find("clock").GetComponent<TextMeshProUGUI>();

        // Give Cards to Both Heros
        StartCoroutine( GenerateCardForPlayer());

    }

    private IEnumerator GenerateCardForPlayer()
    {
        //Debug.Log("perfect now");

        GameObject Cardgo = cardgenerator.RandomGetCard();
        yield return new WaitForSeconds(2.1f);
        handcard.GetCard(Cardgo);

        Cardgo = cardgenerator.RandomGetCard();
        yield return new WaitForSeconds(2.1f);
        handcard.GetCard(Cardgo);

        Cardgo = cardgenerator.RandomGetCard();
        yield return new WaitForSeconds(2.1f);
        handcard.GetCard(Cardgo);

        Cardgo = cardgenerator.RandomGetCard();
        yield return new WaitForSeconds(2.1f);
        handcard.GetCard(Cardgo);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(GenerateCardForPlayer());
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

    
    

}
