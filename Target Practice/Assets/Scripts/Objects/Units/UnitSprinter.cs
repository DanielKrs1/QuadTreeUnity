using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSprinter : Unit
{
    private ISprinterState _state;
    protected override void Init()
    {
        _fact = ServiceLocator.BulletFactory;
        Cooldown = 3000;
    }
    protected override void DoOnCooldown()
    {

    }
    protected override void Move()
    {

    }
}
