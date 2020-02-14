using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    int save = 0;
	// New Game Button
	public void PlayGame()
	{
		SceneManager.LoadScene ("BattleScene");	
    }    

	//Quit Button
	public void QuitGame(){
		Debug.Log("QUIT!");
		Application.Quit();
	}

    public void LoadGame()
    {

        SceneManager.LoadScene(save);
     
    }

    public void ReturnMain()
    {
        SceneManager.LoadScene("Menu");
    }
}
