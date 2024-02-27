using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitWarrior : Unit
{
    int cooldownCounter;
    protected override void Init()
    {
        _fact = ServiceLocator.BulletFactory;
        Cooldown = 0.2f;
        _curTarget = strongestWithinRange(50.0f);
        cooldownCounter = 0;
    }

    
    protected override void DoOnCooldown()
    {
        if (cooldownCounter < 5) // secondary cooldown lol
        {
            cooldownCounter++;
        }
        else
        {
            cooldownCounter = 0;
            _curTarget = strongestWithinRange(50.0f);
            Aim(_curTarget);
        }
        if (_curTarget != null) Fire(_curTarget);

    }

    protected override void Move()
    {
        MoveForward(40);
    }
}

