using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hero", menuName = "Hero")]
public class Hero : ScriptableObject
{

    public new string name;
    
    public Sprite artwork;

    public int health = 30;

    public void Print()
    {
        Debug.Log(name + ": "+ health);
    }


}
