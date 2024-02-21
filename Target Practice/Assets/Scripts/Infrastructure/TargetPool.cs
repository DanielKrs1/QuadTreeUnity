using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPool : MonoBehaviour
{
    // TODO: List of targets, keep track of alive/dead, be able to summon N targets
    // when all targets are dead send the End message

    public List<Target> Targets;

    // TODO: initial setup of targets list - will involve making gameobjects from prefabs
    public void SummonTargets(int targets)
    {
        for (int i = 0; i < targets; i++)
        {
            // maybe set Targets[i].Type randomly if that's something we want to reroll
            Targets[i].Initialize();
        }
    }

    void OnDeath(Target deceased)
    {
        // TODO 
    }
    void Start()
    {
        ServiceLocator.Broker.SubDeath(OnDeath);
    }
}
