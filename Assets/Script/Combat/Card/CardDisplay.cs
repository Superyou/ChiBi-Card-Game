using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

	public Card card;

	public Text nameText;
	public Text descriptionText;

	public Image artworkImage;

	public Text manaText;
	public Text attackText;
	public Text healthText;

	// Use this for initialization
	void Start () {
		nameText.text = card.name;
		descriptionText.text = card.description;

		artworkImage.sprite = card.artwork;

		manaText.text = card.manaCost.ToString();
		attackText.text = card.attack.ToString();
		healthText.text = card.health.ToString();
	}


	// the public method for other gameobject to change this card display
    public void SetCard(Card newcard)
    {
        card = newcard;
        nameText.text = newcard.name;
        descriptionText.text = newcard.description;

        artworkImage.sprite = newcard.artwork;

        manaText.text = newcard.manaCost.ToString();
        attackText.text = newcard.attack.ToString();
        healthText.text = card.health.ToString();
    }





    //When mouse click on any card in your hand, the description card should become visible and show on the screen
    //This part should only appear for the cards in yourHand,YourDeck,EnermyDeck

    // Currently Not Working
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.name == this.gameObject.name)
                {
                    Debug.Log("I am pressed");
                    CardDescript._instance.ShowCard(card);
                }
            }
        }
    }

    

}
