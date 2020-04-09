using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhanceCreatures : CreatureEffect
{

    public EnhanceCreatures(Player owner, CreatureLogic creature, int specialAmount) : base(owner, creature, specialAmount)
    { }

    public override void WhenACreatureIsPlayed()
    {

        CreatureLogic[] CreaturesToEnhance = TurnManager.Instance.whoseTurn.table.CreaturesOnTable.ToArray();
        foreach (CreatureLogic cl in CreaturesToEnhance)
        {
            if (cl != creature)
            {
                
                
                new EnhanceCreatureCommand(cl.ID, specialAmount, healthAfter: cl.Health + specialAmount, attackAfter: cl.Attack + specialAmount).AddToQueue();
                cl.MaxHealth += specialAmount;
                cl.Health += specialAmount;
                cl.Attack += specialAmount;

                Debug.Log("After enhance: Attack " + cl.Attack.ToString());
                Debug.Log("After enhance: Health " + cl.Health.ToString());

            }
        }
    }


    
}
