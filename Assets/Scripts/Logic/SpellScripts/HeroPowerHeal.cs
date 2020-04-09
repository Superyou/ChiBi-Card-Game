using UnityEngine;
using System.Collections;

public class HeroPowerHeal : SpellEffect 
{

    public override void ActivateEffect(int specialAmount = 0, ICharacter target = null)
    {
    	if (TurnManager.Instance.whoseTurn.Health +2 > TurnManager.Instance.whoseTurn.MaxHealth )
    	{
    		new HealCommand(TurnManager.Instance.whoseTurn.PlayerID, 2, TurnManager.Instance.whoseTurn.MaxHealth).AddToQueue();
        	TurnManager.Instance.whoseTurn.Health = TurnManager.Instance.whoseTurn.MaxHealth;
    	}
    	else{
        	new HealCommand(TurnManager.Instance.whoseTurn.PlayerID, 2, TurnManager.Instance.whoseTurn.Health + 2).AddToQueue();
        	TurnManager.Instance.whoseTurn.Health += 2;
        }
        new DealDamageCommand(TurnManager.Instance.whoseTurn.otherPlayer.PlayerID, 2, TurnManager.Instance.whoseTurn.otherPlayer.Health - 2).AddToQueue();
        TurnManager.Instance.whoseTurn.otherPlayer.Health -= 2;
    }
}
