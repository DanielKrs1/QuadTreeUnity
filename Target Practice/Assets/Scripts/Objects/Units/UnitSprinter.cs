using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSprinter : Unit
{ // PATTERN 6: STATE
    public ISprinterState State;  
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
