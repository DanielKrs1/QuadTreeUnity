using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBomber : Unit
{
    protected override void Init()
    {
        _fact = ServiceLocator.BombFactory;
        Cooldown = 3000;
    }
    protected override void DoOnCooldown()
    {

    }
    protected override void Move()
    {

    }
}
