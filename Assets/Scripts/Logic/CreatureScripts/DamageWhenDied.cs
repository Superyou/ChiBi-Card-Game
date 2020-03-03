using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageWhenDied : CreatureEffect
{
    public DamageWhenDied(Player owner, CreatureLogic creature, int specialAmount) : base(owner, creature, specialAmount)
    { }

    public override void WhenACreatureDies()
    {
        new DealDamageCommand(owner.otherPlayer.PlayerID, specialAmount, owner.otherPlayer.Health - specialAmount).AddToQueue();
        owner.otherPlayer.Health -= specialAmount;

    }



}
