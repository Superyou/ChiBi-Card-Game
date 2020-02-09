using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDescript : MonoBehaviour
{
    // Start is called before the first frame update
    public static CardDescript _instance;
    private CardDisplay _card;

    public float Showtime =2f;

    private float timer = 0;
    private bool isShow = false;

    private Color c;

    private void Awake()
    {
        _instance = this;
        _card = this.GetComponent<CardDisplay>();

        this.gameObject.SetActive(false);

        //c = new Color();
        //c.a = 0;
        //_card.artworkImage.color = c;
    }

    private void Update()
    {
        if (isShow)
        {
            timer += Time.deltaTime;
            if(timer > Showtime)
            {
                //_card.artworkImage.color = c;
                this.gameObject.SetActive(false);
                timer = 0;
                isShow = false;
            }
            else
            {
                this.gameObject.SetActive(true);
                //c = _card.artworkImage.color;
                //c.a = (Showtime - timer) / Showtime;
            }
        }

    }
    public void ShowCard(Card card)
    {
        Debug.Log("Pressed");


        _card.SetCard(card);
        this.gameObject.SetActive(true);

        iTween.FadeTo(this.gameObject,0,3f);

        isShow = true;
        timer = 0;

    }
}
