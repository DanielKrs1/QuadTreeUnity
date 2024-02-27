using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPool : MonoBehaviour
{ // PATTERN 3: OBJECT POOL
    public GameObject Prefab;
    public List<Target> Targets;
    public int TargetCount = 1600;
    public List<Target> AliveTargets;

    public void SummonTargets(int targets)
    {
        Debug.Log("Summoning " + targets + " targets");
        for (int i = 0; AliveTargets.Count < targets; i++)
        {
                Targets[i].Initialize();
                AliveTargets.Add(Targets[i]);
        }
    }

    public Target RandomAliveTarget()
    {
        if (AliveTargets.Count == 0) return null;

        int random = Random.Range(0, AliveTargets.Count);
        if (!AliveTargets[random].IsDead)
        {
            return AliveTargets[random];
        }
        Debug.Log("you messed something up");
        return null;
    }

    void OnDeath(Target deceased)
    {
        AliveTargets.Remove(deceased);
        if (AliveTargets.Count == 0)
        {
            ServiceLocator.Broker.PubEnd();
        }
    }

    void OnEnd()
    { // cleanup
        AliveTargets.Clear();
        for (int i = 0; i < Targets.Count; i++)
        {
            Targets[i].gameObject.SetActive(false);
            Targets[i].IsDead = true;
        }
    }
    void Start()
    {
        Targets = new List<Target>();
        AliveTargets = new List<Target>();
        ServiceLocator.Broker.SubDeath(OnDeath);
        ServiceLocator.Broker.SubEnd(OnEnd);
        for (int i = 0; i < TargetCount; i++)
        {
            Targets.Add(Instantiate(Prefab.GetComponent<Target>(), new Vector3(0, 0, 0), Quaternion.identity));
        }
    }
}
