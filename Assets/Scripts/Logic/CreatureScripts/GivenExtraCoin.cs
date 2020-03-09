using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivenExtraCoin : CreatureEffect
{
    public GivenExtraCoin(Player owner, CreatureLogic creature, int specialAmount) : base(owner, creature, specialAmount)
    { }

    public override void WhenACreatureIsPlayed()
    {
         TurnManager.Instance.whoseTurn.GetBonusMana(Random.Range(0, 1+specialAmount));
    }



}
