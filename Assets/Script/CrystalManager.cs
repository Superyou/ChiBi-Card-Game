using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrystalManager : MonoBehaviour
{
    public int TotalCrystal = 1;
    public int CurrentCrystal = 1;

    public TextMeshProUGUI[] crystals;
    public int maxnumber = 10;
    private TextMeshProUGUI my_text;

    private void Awake()
    {
        maxnumber = crystals.Length;
        my_text = GetComponent<TextMeshProUGUI>();
    }
    public void RefreshNum()
    {
        if (TotalCrystal < maxnumber)
        {
            TotalCrystal++;
        }
        CurrentCrystal = TotalCrystal;
    }

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
        for (int i=0;i<TotalCrystal;i++)
        {
            crystals[i].gameObject.SetActive(true);
        }

        for (int i = TotalCrystal; i < maxnumber; i++)
        {
            crystals[i].gameObject.SetActive(false);
        }

        for (int i = CurrentCrystal; i < TotalCrystal; i++)
        {
            crystals[i].text = "*";
        }

        for (int i = 1; i <= CurrentCrystal; i++)
        {

            crystals[i-1].text = i.ToString();
        }


        my_text.text = CurrentCrystal + "/" + TotalCrystal;


    }

    public void OnNewTurn(string heroName)
    {
        if(heroName == "Player")
        {
            RefreshNum();
        }
    }
    private void Start()
    {
        GameManager._instance.OnNewTurn += this.OnNewTurn;
    }

}
