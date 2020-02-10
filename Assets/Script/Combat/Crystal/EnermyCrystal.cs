using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//The script to controll enermy's crystal display
public class EnermyCrystal : MonoBehaviour
{
    // The maximum crystal can use in this turn
    public int TotalCrystal = 1;
    // The current crystal num at this time
    public int CurrentCrystal = 1;

    // maximum crystal num is 10
    public int maxnumber = 10;
    private TextMeshProUGUI my_text;


    private void Awake()
    {
        
        my_text = GetComponent<TextMeshProUGUI>();
    }

    // The method to add totalcrystal, and reset the currentCrstal for each new turn
    public void RefreshNum()
    {
        if (TotalCrystal < maxnumber)
        {
            TotalCrystal++;
        }
        CurrentCrystal = TotalCrystal;
    }

    // the check whether the current crystal is enough to play a card, if we can, decrease the current crystal
    public bool CostCrystal(int num)
    {
        if (CurrentCrystal >= num)
        {
            CurrentCrystal -= num;
            return true;
        }
        return false;
    }

    void Update()
    {
        // Show the text message
        my_text.text = CurrentCrystal + "/" + TotalCrystal;
    }

    //Listening events on new turns
    public void OnNewTurn(string heroName)
    {
        if(heroName == "Enermy")
        {
            //do not update crystal for the first round 
            if (GameManager._instance.TurnIndex >= 2)
            {
                RefreshNum();
            }
        }
    }
    private void Start()
    {
        //add Listening events to gamemanager
        GameManager._instance.OnNewTurn += this.OnNewTurn;
    }
}
