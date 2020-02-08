using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldMap : MonoBehaviour
{

    public void OnClick()
    {
        Debug.Log("Button Clicked. Go to Battle.");
        //SceneManager.LoadScene("Combat");
        SceneManager.LoadScene(2);
    }

}
