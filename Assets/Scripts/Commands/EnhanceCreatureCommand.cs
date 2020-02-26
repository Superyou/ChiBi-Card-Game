using UnityEngine;
using System.Collections;

public class EnhanceCreatureCommand : Command {

    private int targetID;
    private int amount;
    private int healthAfter;
    private int attackAfter;

    public EnhanceCreatureCommand( int targetID, int amount, int healthAfter, int attackAfter)
    {
        this.targetID = targetID;
        this.amount = amount;
        this.healthAfter = healthAfter;
        this.attackAfter = attackAfter;
        
    }

    public override void StartCommandExecution()
    {
        Debug.Log("In Enhance creatures command!");

        GameObject target = IDHolder.GetGameObjectWithID(targetID);

        target.GetComponent<OneCreatureManager>().TakeHeal(amount, healthAfter);
        target.GetComponent<OneCreatureManager>().ChangeAttack(amount, attackAfter);
        
        CommandExecutionComplete();
    }
}
