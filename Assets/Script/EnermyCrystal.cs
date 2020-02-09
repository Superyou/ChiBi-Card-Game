using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnermyCrystal : MonoBehaviour
{
    public int TotalCrystal = 1;
    public int CurrentCrystal = 1;

    public int maxnumber = 10;
    private TextMeshProUGUI my_text;

    private void Awake()
    {
        
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

    void Update()
    {
        my_text.text = CurrentCrystal + "/" + TotalCrystal;
    }
}
