using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu(fileName = "New Deck", menuName = "Deck")]
public class DeckManage : ScriptableObject
{
	public int size = 20;
    public Card[] allDeck = new Card[20];
    public bool[] used = new bool[20];
 
	public Card getCard()
    {
     for(int i = 0;i<20;i++){
     	if(used[i] == false){
     		used[i] = true;
     		return allDeck[i];
     	}
     }
     return allDeck[Random.Range(0,4)];   	
    }

    public Card getCard(int cost){
    	for(int i = 0;i<20;i++){
     	if((used[i] == false&&allDeck[i].manaCost <= cost)){
     		used[i] = true;
     		return allDeck[i];
     	}
     }
     return allDeck[Random.Range(0,4)];   
    }

    void resetDeck(){
    	for(int i = 0;i<20;i++){
    		used[i] = false;
    	}
    }
}
