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
    private int hp;

    // Use this for initialization
    void Start()
    {
        nameText.text = hero.name;
        
        artworkImage.sprite = hero.artwork;
        healthText.text = hero.health.ToString();
        hp = hero.health;
    }

    public void TakeDamage(int damage)
    {
        hp-=damage;
        healthText.text = hp.ToString();
        if(hp < 0)
        {
            //END GAME
        }
    }
    public void healHP(int num)
    {
        hp += num;
        if(hp>=30)
        {
            hp = 30;
        }

        healthText.text = hp.ToString();
    }


}
