using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void LevelOne()
    {
        SceneManager.LoadScene ("Level1"); 
    }
    public void LevelEight()
    {
        SceneManager.LoadScene ("Level8"); 
    }
     public void LevelTwo()
    {
        SceneManager.LoadScene ("Level2"); 
    }  
}
