using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawExtraCard : CreatureEffect
{
    public DrawExtraCard(Player owner, CreatureLogic creature, int specialAmount) : base(owner, creature, specialAmount)
    { }

    public override void WhenACreatureIsPlayed()
    {
         TurnManager.Instance.whoseTurn.DrawACard();
    }



}
