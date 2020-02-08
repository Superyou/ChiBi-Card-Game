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
        my_text.text = "Enermy Turn";
    }
}
