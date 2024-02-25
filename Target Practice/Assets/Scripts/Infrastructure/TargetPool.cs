using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPool : MonoBehaviour
{ // PATTERN 3: OBJECT POOL
    // TODO: List of targets, keep track of alive/dead, be able to summon N targets
    // when all targets are dead send the End message

    public GameObject Prefab;
    public List<Target> Targets;
    public int TargetCount = 1600;
    public int AliveTargets;

    public void SummonTargets(int targets)
    {
        for (int i = 0; AliveTargets < targets; i++)
        {
            if (Targets[i].IsDead)
            {
                Targets[i].Initialize();
                AliveTargets++;
            }
        }
    }

    void OnDeath(Target deceased)
    {
        AliveTargets--;
        if (AliveTargets == 0)
        {
            ServiceLocator.Broker.PubEnd();
        }
    }
    void Start()
    {
        ServiceLocator.Broker.SubDeath(OnDeath);
        AliveTargets = 0;
        for (int i = 0; i < TargetCount; i++)
        {
            Targets.Add(Instantiate(Prefab.GetComponent<Target>(), new Vector3(0, 0, 0), Quaternion.identity));
        }
    }
}
