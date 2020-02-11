using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

	public Card card;

	public Text nameText;
    public Text cpnameText;
	public Text descriptionText;

	public Image artworkImage;
    public Image cpartworkImage;

    public Text cpmanaText;
	public Text manaText;
	public Text attackText;
    public Text cpattackText;
	public Text healthText;
    public Text cphealthText;
    public Text detailText;

	// Use this for initialization
	void Start () {
		nameText.text = card.name;
        cpnameText.text = card.name;
		descriptionText.text = card.description;

		artworkImage.sprite = card.artwork;
        cpartworkImage.sprite = card.artwork;

		manaText.text = card.manaCost.ToString();
        cpmanaText.text = card.manaCost.ToString();
		attackText.text = card.attack.ToString();
        cpattackText.text = card.attack.ToString();
		healthText.text = card.health.ToString();
        cphealthText.text = card.health.ToString();
        detailText.text = card.detail;
	}
	
    public void SetCard(Card newcard)
    {
        card = newcard;
        nameText.text = newcard.name;
        cpnameText.text = newcard.name;
        descriptionText.text = newcard.description;
        cpartworkImage.sprite = newcard.artwork;
        artworkImage.sprite = newcard.artwork;
        cpmanaText.text = newcard.manaCost.ToString();
        manaText.text = newcard.manaCost.ToString();
        attackText.text = newcard.attack.ToString();
        cpattackText.text = newcard.attack.ToString();
        healthText.text = newcard.health.ToString();
        cphealthText.text = newcard.health.ToString();
        detailText.text = newcard.detail;
    }


    //This part should only appear for the cards in yourHand,YourDeck,EnermyDeck

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
