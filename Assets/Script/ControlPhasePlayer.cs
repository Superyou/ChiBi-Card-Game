using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Turns/Control Phase Player")]
public class ControlPhasePlayer : Phase
{

    //public GameStates.State playerControlState;

    public override bool IsComplete()
    {
        // To do with the action at end of each turn



        return false;
    }
    
    public override void OnStartPhase()
    {
        /*
        if (!isInit)
        {
            Settings.gameManager.SetState(playerControlState);
            isInit = true;
        }
        */

    }


    public override void OnEndPhase()
    {
        /*
        if(isInit)
        {
            
            isInit = false;
        }
        */

    }
    
}
