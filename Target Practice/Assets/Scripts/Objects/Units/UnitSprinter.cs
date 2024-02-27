using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSprinter : Unit
{
    private ISprinterState _state;  // PATTERN 6: STATE
    protected override void Init()
    {
        _fact = ServiceLocator.BulletFactory;
        Cooldown = 1;
    }
    protected override void DoOnCooldown()
    {
        _state.Act();
    }
    protected override void Move()
    {

    }
}
