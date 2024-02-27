using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnitBomber : Unit
{

    protected override void Init()
    {
        _fact = ServiceLocator.BombFactory;
        Cooldown = 1;
    }


    protected override void DoOnCooldown()
    {
        _curTarget = strongestWithinRange(100.0f);
        Aim(_curTarget);
        if (_curTarget != null) Fire(_curTarget);
    }

    protected override void Move()
    {
        MoveForward(25);
    }
}
