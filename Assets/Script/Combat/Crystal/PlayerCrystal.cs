using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//The script to controll player's crystal display
public class PlayerCrystal : MonoBehaviour
{
    // The maximum crystal can use in this turn
    public int TotalCrystal = 1;
    // The current crystal num at this time
    public int CurrentCrystal = 1;

    // The crystal components
    // current are Texts, should change to figures and sprites in future
    public TextMeshProUGUI[] crystals;

    // maximum crystal num is 10
    public int maxnumber = 10;
    private TextMeshProUGUI my_text;

    private void Awake()
    {
        maxnumber = crystals.Length;
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

    // Update is called once per frame
    void Update()
    {
        //display the crystal components we can use in this turn
        for (int i=0;i<TotalCrystal;i++)
        {
            crystals[i].gameObject.SetActive(true);
        }

        //disable the other components
        for (int i = TotalCrystal; i < maxnumber; i++)
        {
            crystals[i].gameObject.SetActive(false);
        }

        // set the used cystal components to "*", others should be defaulted nums
        for (int i = CurrentCrystal; i < TotalCrystal; i++)
        {
            crystals[i].text = "*";
        }
        for (int i = 1; i <= CurrentCrystal; i++)
        {

            crystals[i-1].text = i.ToString();
        }

        // Show the text message
        my_text.text = CurrentCrystal + "/" + TotalCrystal;


    }

    //Listening events on new turns
    public void OnNewTurn(string heroName)
    {
        if(heroName == "Player")
        {
            //Update crystal for Player on new turns
            RefreshNum();
        }
    }
    private void Start()
    {
        //add Listening events to gamemanager
        GameManager._instance.OnNewTurn += this.OnNewTurn;
    }

}
