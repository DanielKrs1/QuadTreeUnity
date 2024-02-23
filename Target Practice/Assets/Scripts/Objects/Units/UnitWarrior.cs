using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitWarrior : Unit
{
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
