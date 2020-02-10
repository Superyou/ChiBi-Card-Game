using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

//This script will be used for the Endturn button 

public class EndTurn : MonoBehaviour
{

    //The text component for display
    private TextMeshProUGUI my_text;

    private void Awake()
    {
        // Get the TMPro child of this Button
        my_text = GetComponentInChildren<TextMeshProUGUI>();

    }

    
    public void OnEndTurnClick()
    {
        //When click on the button, the text should change to "enermy turn"
        //The gamemanager should give control to the enermy
        if (my_text.text == "End Turn")
        {
            my_text.text = "Enermy Turn";
            GameManager._instance.TransformPlayer();

        }
        
    }

    public void OnNewTurn(string heroName)
    {
        //the Event to do on each new Turn,
        // When current the control is gaven to the player, botton should display "End Turn"
        if(heroName == "Player")
        {
            my_text.text = "End Turn";
        }
    }

    private void Start()
    {
        // Add the listening event to OnNewTurn
        GameManager._instance.OnNewTurn += this.OnNewTurn;
    }


}
