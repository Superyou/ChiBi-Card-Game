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
		SceneManager.LoadScene ("SelectScene");	
    }    

    	public void TestGame()
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
        IDFactory.ResetIDs();
        IDHolder.ClearIDHoldersList();
        Command.CommandQueue.Clear();
        Command.CommandExecutionComplete();
        SceneManager.LoadScene("Menu");
    }
     public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LevelOne()
    {
        SceneManager.LoadScene ("Level1"); 
    }
    public void LevelEight()
    {
        SceneManager.LoadScene ("Level8"); 
    } 
}
