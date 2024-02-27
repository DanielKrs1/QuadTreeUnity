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
        if (_curTarget == null)
        {
            Aim(new Vector3(Random.Range(0, 300), Random.Range(0, 200), 0));
        }
        else
        {
            Aim(_curTarget.transform);
            Fire(_curTarget);
        }
    }

    protected override void Move()
    {
        transform.position += transform.up * 25 * Time.deltaTime;
    }
}
