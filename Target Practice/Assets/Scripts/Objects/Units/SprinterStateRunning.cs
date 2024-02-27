using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinterStateRunning : ISprinterState
{
    public void Act(UnitSprinter sprinter)
    {
        sprinter._curTarget = sprinter.strongestWithinRange(50.0f);
        if (Vector3.Distance(sprinter.transform.position, sprinter._curTarget.transform.position) > 1.0f)
        {
            sprinter.Aim(sprinter._curTarget);
            sprinter.MoveForward(100);
        }
        else
        {
            Change(sprinter);
        }
    }

    public void Change(UnitSprinter sprinter)
    {
        sprinter.State = new SprinterStateFiring();
    }
}
