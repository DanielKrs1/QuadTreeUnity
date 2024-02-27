using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSprinter : Unit
{
    public ISprinterState State;  // PATTERN 6: STATE
    protected override void Init()
    {
        _fact = ServiceLocator.BulletFactory;
        Cooldown = 1.5f;
        State = new SprinterStateRunning();
    }
    protected override void DoOnCooldown()
    {
        State.Change(this);
    }
    protected override void Move()
    {
        State.Act(this);
    }

}
