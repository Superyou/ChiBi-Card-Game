using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Turns/Battle Phase Player")]
public class BattlePhase : Phase
{
    public override bool IsComplete()
    {
        // To do with the action at end of each turn

        return false;
    }

    public override void OnStartPhase()
    {

    }


    public override void OnEndPhase()
    {


    }
}
