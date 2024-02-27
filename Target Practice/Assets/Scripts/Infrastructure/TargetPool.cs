using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPool : MonoBehaviour
{ // PATTERN 3: OBJECT POOL
    public GameObject Prefab;
    public List<Target> Targets;
    public int TargetCount = 1600;
    public int AliveTargets;

    public void SummonTargets(int targets)
    {
        Debug.Log("Summoning " + targets + " targets");
        for (int i = 0; AliveTargets < targets; i++)
        {
                Targets[i].Initialize();
                AliveTargets++;
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

    void OnEnd()
    { // cleanup
        AliveTargets = 0;
        for (int i = 0; i < Targets.Count; i++)
        {
            Targets[i].gameObject.SetActive(false);
            Targets[i].IsDead = true;
        }
    }
    void Start()
    {
        Targets = new List<Target>();
        ServiceLocator.Broker.SubDeath(OnDeath);
        ServiceLocator.Broker.SubEnd(OnEnd);
        AliveTargets = 0;
        for (int i = 0; i < TargetCount; i++)
        {
            Targets.Add(Instantiate(Prefab.GetComponent<Target>(), new Vector3(0, 0, 0), Quaternion.identity));
        }
    }
}
