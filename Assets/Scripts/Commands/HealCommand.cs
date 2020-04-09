
using UnityEngine;
using System.Collections;


public class HealCommand : Command
{
    
    private int targetID;
    private int amount;
    private int healthAfter;

    public HealCommand( int targetID, int amount, int healthAfter)
    {
        this.targetID = targetID;
        this.amount = amount;
        this.healthAfter = healthAfter;

    }

    public override void StartCommandExecution()
    {
        Debug.Log("In Heal command!");

        GameObject target = IDHolder.GetGameObjectWithID(targetID);
        if (targetID == GlobalSettings.Instance.LowPlayer.PlayerID || targetID == GlobalSettings.Instance.TopPlayer.PlayerID)
        {
            // target is a hero
            target.GetComponent<PlayerPortraitVisual>().TakeHeal(amount,healthAfter);
        }
        else
        {
            // target is a creature
            target.GetComponent<OneCreatureManager>().TakeHeal(amount, healthAfter);

        }
        CommandExecutionComplete();
    }
}
