using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDescript : MonoBehaviour
{

    //the static object CardDescription 
    public static CardDescript _instance;

    // This is the cardDisplay located on the left of the desk, it will change its
    // content according to the gameobject you clicked on
    private CardDisplay _card;

    //the time that a cardDisplay will show for each mouse click
    public float Showtime =2f;

    private float timer = 0;

    //whether the card is vissible now
    private bool isShow = false;

    private Color c;

    private void Awake()
    {
        _instance = this;
        _card = this.GetComponent<CardDisplay>();

        this.gameObject.SetActive(false);

        // We want to change the alpha value to make the fade disappear
        //c = new Color();
        //c.a = 0;
        //_card.artworkImage.color = c;
    }

    private void Update()
    {
        if (isShow)
        {
            //If the description card is visible, increase the timer, and check whether timer up for display
            timer += Time.deltaTime;
            if(timer > Showtime)
            {

                //If time up, deactivate the card display, reset the timmer 

                //_card.artworkImage.color = c;
                this.gameObject.SetActive(false);
                timer = 0;
                isShow = false;
            }
            else
            {
                //not time up, still display the card, but change alpha value and make it fade 

                this.gameObject.SetActive(true);
                //c = _card.artworkImage.color;
                //c.a = (Showtime - timer) / Showtime;
            }
        }

    }


    // the method to be used outside, when you click on a card object
    public void ShowCard(Card card)
    {
        Debug.Log("Pressed");

        //Set the content of the display card
        _card.SetCard(card);
        this.gameObject.SetActive(true);

        // make the fade cartoon 
        iTween.FadeTo(this.gameObject,0,3f);

        //reset the timmer and flag

        isShow = true;
        timer = 0;

    }
}
