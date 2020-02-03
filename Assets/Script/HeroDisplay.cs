using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroDisplay : MonoBehaviour
{

    public Hero hero;

    public Text nameText;

    public Image artworkImage;

    public Text healthText;

    // Use this for initialization
    void Start()
    {
        nameText.text = hero.name;
        
        artworkImage.sprite = hero.artwork;
        healthText.text = hero.health.ToString();
    }

}
