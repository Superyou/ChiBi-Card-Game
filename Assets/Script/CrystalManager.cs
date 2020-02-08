using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrystalManager : MonoBehaviour
{
    public int TotalCrystal = 1;
    public int CurrentCrystal = 1;

    public TextMeshProUGUI[] crystals;
    private int totalnumber;
    private TextMeshProUGUI my_text;

    private void Awake()
    {
        totalnumber = crystals.Length;
        my_text = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0;i<TotalCrystal;i++)
        {
            crystals[i].gameObject.SetActive(true);
        }

        for (int i = TotalCrystal; i < totalnumber; i++)
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


}
