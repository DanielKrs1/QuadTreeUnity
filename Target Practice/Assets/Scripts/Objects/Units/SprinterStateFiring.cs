using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinterStateFiring : ISprinterState
{
    float _firingTime = 0;

    public SprinterStateFiring()
    {
        _firingTime = Time.time - 0.1f;
    }
    public void Act(UnitSprinter sprinter)
    {
        if (Time.time > _firingTime)
        {
            _firingTime += 0.07f;
            fire(sprinter);
        }
    }

    void fire(UnitSprinter sprinter)
    {
        List<Target> victims = ServiceLocator.QuadTree.Query(sprinter.transform.position, 40.0f);

        if (victims.Count == 0)
        {
            Change(sprinter);
            return;
        }
        Target victim = victims[Random.Range(0, victims.Count)];

        sprinter.Fire(victim);
    }

    public void Change(UnitSprinter sprinter)
    {
        sprinter.State = new SprinterStateRunning();
    }
}
