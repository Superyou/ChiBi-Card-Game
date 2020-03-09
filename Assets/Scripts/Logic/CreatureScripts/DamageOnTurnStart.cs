using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTurnStart : CreatureEffect
{

    public DamageOnTurnStart(Player owner, CreatureLogic creature, int specialAmount) : base(owner, creature, specialAmount)
    { }

    public override void WhenTurnStart()
    {

      new DealDamageCommand(owner.otherPlayer.PlayerID, specialAmount, owner.otherPlayer.Health - specialAmount).AddToQueue();
        owner.otherPlayer.Health -= specialAmount;

            }
        }
    


    
