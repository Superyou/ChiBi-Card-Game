using UnityEngine;
using System.Collections;

public abstract class CreatureEffect 
{
    protected Player owner;
    protected CreatureLogic creature;
    protected int specialAmount;

    public CreatureEffect(Player owner, CreatureLogic creature, int specialAmount)
    {
        this.creature = creature;
        this.owner = owner;
        this.specialAmount = specialAmount;
    }

    public virtual void RegisterEffect() { }

    public virtual void CauseEffect() { }

    //Battlecry
    public virtual void WhenACreatureIsPlayed() { }

    //Deathrattle
    public virtual void WhenACreatureDies() { }

    public virtual void WhenTurnStart(){}


}
