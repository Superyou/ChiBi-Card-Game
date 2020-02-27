using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class CreatureLogic: ICharacter 
{
    // PUBLIC FIELDS
    public Player owner;
    public CardAsset ca;
    public CreatureEffect effect;
    public int UniqueCreatureID;
    public bool Frozen = false;

    // PROPERTIES
    // property from ICharacter interface
    public int ID
    {
        get{ return UniqueCreatureID; }
    }
        
    // the basic health that we have in CardAsset
    private int baseHealth;
    // health with all the current buffs taken into account
    public int MaxHealth
    {
        get{ return baseHealth;}
    }

    // current health of this creature
    private int health;

    private Minion MinionType;

    public int Health
    {
        get{ return health; }

        set
        {
            if (value > MaxHealth)
                health = baseHealth;
            else if (value <= 0)
                Die();
            else
                health = value;
        }
    }

    // returns true if we can attack with this creature now
    public bool CanAttack
    {
        get
        {
            bool ownersTurn = (TurnManager.Instance.whoseTurn == owner);
            return (ownersTurn && (AttacksLeftThisTurn > 0) && !Frozen);
        }
    }

    // property for Attack
    private int baseAttack;
    public int Attack
    {
        get{ return baseAttack; }
    }
     
    // number of attacks for one turn if (attacksForOneTurn==2) => Windfury
    private int attacksForOneTurn = 1;
    public int AttacksLeftThisTurn
    {
        get;
        set;
    }

    // CONSTRUCTOR
    public CreatureLogic(Player owner, CardAsset ca)
    {
        this.ca = ca;
        baseHealth = ca.MaxHealth;
        Health = ca.MaxHealth;
        baseAttack = ca.Attack;
        attacksForOneTurn = ca.AttacksForOneTurn;

        //
        MinionType = ca.MinionType;

        // AttacksLeftThisTurn is now equal to 0
        if (ca.Charge)
            AttacksLeftThisTurn = attacksForOneTurn;
        this.owner = owner;
        UniqueCreatureID = IDFactory.GetUniqueID();
        if (ca.CreatureScriptName!= null && ca.CreatureScriptName!= "")
        {
            effect = System.Activator.CreateInstance(System.Type.GetType(ca.CreatureScriptName), new System.Object[]{owner, this, ca.specialCreatureAmount}) as CreatureEffect;
            effect.RegisterEffect();
        }
        CreaturesCreatedThisGame.Add(UniqueCreatureID, this);
    }

    // METHODS
    public void OnTurnStart()
    {
        AttacksLeftThisTurn = attacksForOneTurn;
    }

    public void Die()
    {   
        owner.table.CreaturesOnTable.Remove(this);

        if (effect != null)
            effect.WhenACreatureDies();

        new CreatureDieCommand(UniqueCreatureID, owner).AddToQueue();
    }

    public void GoFace()
    {
        AttacksLeftThisTurn--;
        int targetHealthAfter = owner.otherPlayer.Health - Attack;
        new CreatureAttackCommand(owner.otherPlayer.PlayerID, UniqueCreatureID, 0, Attack, Health, targetHealthAfter).AddToQueue();
        owner.otherPlayer.Health -= Attack;
    }

    public void AttackCreature (CreatureLogic target)
    {
        AttacksLeftThisTurn--;
        // calculate the values so that the creature does not fire the DIE command before the Attack command is sent

        int targetHealthAfter;
        int attackerHealthAfter;
        
        if (target.MinionType == Minion.Calvary && this.MinionType == Minion.Footman || target.MinionType == Minion.Archer && this.MinionType == Minion.Calvary || target.MinionType == Minion.Footman && this.MinionType == Minion.Archer)
        {
            targetHealthAfter = target.Health - 2* Attack;
            attackerHealthAfter = Health - target.Attack;
            new CreatureAttackCommand(target.UniqueCreatureID, UniqueCreatureID, target.Attack, 2*Attack, attackerHealthAfter, targetHealthAfter).AddToQueue();
        }
        else if (this.MinionType == Minion.Calvary && target.MinionType == Minion.Footman || this.MinionType == Minion.Archer && target.MinionType == Minion.Calvary || this.MinionType == Minion.Footman && target.MinionType == Minion.Archer)
        {
            targetHealthAfter = target.Health - Attack;
            attackerHealthAfter = Health - 2*target.Attack;
            new CreatureAttackCommand(target.UniqueCreatureID, UniqueCreatureID, 2*target.Attack, Attack, attackerHealthAfter, targetHealthAfter).AddToQueue();
        }
        else
                {
            targetHealthAfter = target.Health - Attack;
            attackerHealthAfter = Health - target.Attack;
            new CreatureAttackCommand(target.UniqueCreatureID, UniqueCreatureID, target.Attack, Attack, attackerHealthAfter, targetHealthAfter).AddToQueue();
        }

            
        
        //new CreatureAttackCommand(target.UniqueCreatureID, UniqueCreatureID, target.Attack, Attack, attackerHealthAfter, targetHealthAfter).AddToQueue();

        target.Health = targetHealthAfter;
        Health = attackerHealthAfter;
    }

    public void AttackCreatureWithID(int uniqueCreatureID)
    {
        CreatureLogic target = CreatureLogic.CreaturesCreatedThisGame[uniqueCreatureID];
        AttackCreature(target);
    }

    // STATIC For managing IDs
    public static Dictionary<int, CreatureLogic> CreaturesCreatedThisGame = new Dictionary<int, CreatureLogic>();

}
