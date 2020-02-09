using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class EndTurn : MonoBehaviour
{
    private TextMeshProUGUI my_text;

    private void Awake()
    {
        
        my_text = GetComponentInChildren<TextMeshProUGUI>();

    }


    public void OnEndTurnClick()
    {
        if (my_text.text == "End Turn")
        {
            my_text.text = "Enermy Turn";
            GameManager._instance.TransformPlayer();

        }
        
    }

    public void OnNewTurn(string heroName)
    {
        if(heroName == "Player")
        {
            my_text.text = "End Turn";
        }
    }

    private void Start()
    {
        GameManager._instance.OnNewTurn += this.OnNewTurn;
    }


}
