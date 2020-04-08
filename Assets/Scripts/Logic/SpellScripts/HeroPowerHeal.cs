﻿using UnityEngine;
using System.Collections;

public class HeroPowerHeal : SpellEffect 
{

    public override void ActivateEffect(int specialAmount = 0, ICharacter target = null)
    {
        new DealDamageCommand(TurnManager.Instance.whoseTurn.PlayerID, 2, TurnManager.Instance.whoseTurn.Health + 2).AddToQueue();
        TurnManager.Instance.whoseTurn.Health += 2;
        new DealDamageCommand(TurnManager.Instance.whoseTurn.otherPlayer.PlayerID, 2, TurnManager.Instance.whoseTurn.otherPlayer.Health - 1).AddToQueue();
        TurnManager.Instance.whoseTurn.otherPlayer.Health -= 1;
    }
}
