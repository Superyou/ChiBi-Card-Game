using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Turns/Turn")]
public class Turn : ScriptableObject
{
    [System.NonSerialized]
    public int index = 0;

    public Phase[] phases;

    public bool Execute()
    {
        bool result = false;

        phases[index].OnStartPhase();

        bool next = phases[index].IsComplete();
        if (next)
        {
            phases[index].OnEndPhase();
            index++;
            if (index > phases.Length - 1)
            {
                index = 0;
                result = true;
            }
        }
        return result;
    }
}
