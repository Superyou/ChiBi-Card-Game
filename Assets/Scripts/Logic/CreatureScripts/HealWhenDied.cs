using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealWhenDied : CreatureEffect
{
    public HealWhenDied(Player owner, CreatureLogic creature, int specialAmount) : base(owner, creature, specialAmount)
    { }

    public override void WhenACreatureDies()
    {
        new DealDamageCommand(owner.PlayerID, specialAmount, owner.Health + specialAmount).AddToQueue();
        owner.Health += specialAmount;
    }



}