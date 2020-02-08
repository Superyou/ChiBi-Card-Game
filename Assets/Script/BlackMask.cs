﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMask : MonoBehaviour
{
    public static BlackMask _instance;
    void Awake()
    {
        _instance = this;
        this.gameObject.SetActive(true);
    }
    

    private IEnumerator StartShow()
    {
        yield return new WaitForSeconds(3f);
        this.gameObject.SetActive(false);
    }

    void Start()
    {
        StartCoroutine(StartShow());
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }


    /*
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.gameObject.SetActive(false);
        }
    }
    */

}
